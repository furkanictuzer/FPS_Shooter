using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GroundController groundController;
    [SerializeField] private Enemy enemy;
    [SerializeField] private EnemyAnimatorController animatorController;
    [SerializeField] private LayerMask targetLayer;

    [SerializeField] private int damageAmount = 10;
    
    private PatrolController _patrolController;
    
    private CharacterController _characterController;
    
    private Vector3 _targetLocation;
    private bool _shouldMove = true;

    private IState _state;

    private Vector3 _velocity;
    private Vector3 _lastPosition;

    [SerializeField] private DamageableObject _chasedObject;

    private StateType _stateType;

    private const float SearchingAngle = 60;
    private const float CheckForTargetRadius = 4;

    private const float MinimumAttackDistance = 2f;
    
    private const float TargetDistance = 0.5f;
    private const float DestroyDelay = 1.5f;

    private bool _canSeeTarget;
    public EnemyAnimatorController EnemyAnimatorController => animatorController;
    
    public float speed = 5;
    public bool isMoving;
    private void Awake()
    {
        _patrolController = GetComponentInParent<PatrolController>();
        _characterController = GetComponent<CharacterController>();
        
        ChangeState(new WalkingState());
    }

    private void Start()
    {
        animatorController.SetWalkingConstant(speed / 2f);
        GetNewTargetPoint();
    }

    private void Update()
    {
        _state.UpdateState(this);
    }
    
    public void SetState(StateType stateType)
    {
        _stateType = stateType;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, CheckForTargetRadius);
    }
    
    public void MoveTarget()
    {
        if (!_shouldMove) return;

        Vector3 target = _chasedObject == null ? _targetLocation : _chasedObject.transform.position;
        
        if (_velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        Vector3 direction = (target - transform.position).normalized;

        float x = direction.x;
        float z = direction.z;

        _velocity.x = direction.x;
        _velocity.z = direction.z;
                
        _characterController.Move(direction * speed * Time.deltaTime);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)),
                Time.deltaTime * 10);
                
        if (_lastPosition != transform.position)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        _lastPosition = transform.position;

        //Check For Touching Ground
        if (!groundController.IsGrounded)
        {
            Vector3 position = transform.position;

            position.y = groundController.groundPos.y;
        }
        
        
        CheckDistanceWithPatrolPoint();
    }

    private void CheckDistanceWithPatrolPoint()
    {
        float distance = Vector3.Distance(transform.position, _targetLocation);

        if (distance < TargetDistance)
        {
            GetNewTargetPoint();
            
            ChangeState(new IdleState());
        }
    }

    private void GetNewTargetPoint()
    {
        _targetLocation = _patrolController.GetRandomPatrolPoint();
    }

    public void ChangeState(IState newState)
    {
        if (_state != null)
        {
            _state.ExitState(this);
        }

        _state = newState;

        _state.EnterState(this);
    }

    public void DestroyWithDelay()
    {
        StartCoroutine(DestroyCoroutine());
    }
    
    public void CheckForTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, CheckForTargetRadius, targetLayer);
        
        if (colliders.Length != 0)
        {
            Transform target = colliders[0].transform;
            Vector3 directionToTarget = (target.position - transform.forward).normalized;
            float angleBetween = Vector3.Angle(directionToTarget, transform.position);
            Debug.Log("Angle: "+angleBetween);
            
            if (angleBetween < SearchingAngle / 2)
            {
                DamageableObject damageableObject = target.GetComponent<DamageableObject>();
                
                if (damageableObject != null && !damageableObject.IsDead)
                {
                    SetChasedObject(damageableObject);
                }
                else
                {
                    ResetChasedObject();
                }
            }
            else
            {
                ResetChasedObject();
            }
        }
        else if (_chasedObject != null)
        {
            ResetChasedObject();
        }
    }

    private void ResetChasedObject()
    {
        SetChasedObject(null);
    }
    
    private void SetChasedObject(DamageableObject target)
    {
        _chasedObject = target;
        _canSeeTarget = target != null;
    }

    public void CheckForAttack()
    {
        if (_chasedObject == null) return;

        float distance = Vector3.Distance(_chasedObject.transform.position, transform.position);

        switch (distance)
        {
            case < MinimumAttackDistance when _stateType != StateType.Attack:
                ChangeState(new AttackState());
                break;
            case >= MinimumAttackDistance when _stateType != StateType.Walking:
                ChangeState(new WalkingState());
                break;
        }
    }
    
    public void DestroyObject()
    {
        Destroy(gameObject);
        
        _patrolController.SpawnNewEnemyWithDelay();
    }

    public void DamageTarget()
    {
        if (_chasedObject == null) return;
        
        _chasedObject.TakeDamage(damageAmount);
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(DestroyDelay);
        
        DestroyObject();
    }
    

}
