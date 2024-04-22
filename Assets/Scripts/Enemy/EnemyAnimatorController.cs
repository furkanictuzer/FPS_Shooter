using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Animator animator;

    public void SetWalkingConstant(float constant)
    {
        animator.SetFloat("WalkingConstant", constant);
    }
    public void PlayWalking()
    {
        animator.SetTrigger("Walking");
    }

    public void PlayIdle()
    {
        animator.SetTrigger("Idle");
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }
    
    public void PlayDie()
    {
        animator.SetTrigger("Die");
    }

    public void DestroyObject()
    {
        enemyController.DestroyWithDelay();
    }

    public void DamageTarget()
    {
        enemyController.DamageTarget();
    }
}
