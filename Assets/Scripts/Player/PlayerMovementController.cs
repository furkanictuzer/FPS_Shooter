using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementController : MonoBehaviour
{
        [SerializeField] private Player player;
        [Space]
        [SerializeField] private float speed = 8f;
        [SerializeField] private float sprintSpeed = 12f;
        [SerializeField] private float gravity = -9.81f * 2;
        [SerializeField] private float jumpHeight = 3f;
        
        private CharacterController _characterController;
        
        private Vector3 _velocity;
        private Vector3 _lastPosition;

        public event Action<bool> IsMovingChanged;

        public bool IsMoving
        {
                get => _isMoving;
                private set
                {
                        if (IsMoving != value)
                        {
                                IsMovingChanged?.Invoke(value);
                        }

                        _isMoving = value;
                }
        }

        private bool _isMoving;

        private bool IsGrounded => player.GroundController.IsGrounded;

        private float _speedToUse;
        
        public float Speed
        { 
                get
                {
                        Vector2 velocity = new Vector2(_velocity.x, _velocity.z);

                        return velocity.magnitude;
                }
        }

        private void Awake()
        {
                _characterController = GetComponent<CharacterController>();
                _speedToUse = speed;
        }

        private void OnEnable()
        {
                player.PlayerInputController.OnJumpPressed += Jump;
                
                player.PlayerInputController.OnSprintStarted += OnSprintButtonDown;
                player.PlayerInputController.OnSprintStopped += OnSprintButtonUp;
        }

        private void OnDisable()
        {
                player.PlayerInputController.OnJumpPressed -= Jump;
                
                player.PlayerInputController.OnSprintStarted -= OnSprintButtonDown;
                player.PlayerInputController.OnSprintStopped -= OnSprintButtonUp;
        }

        private void Update()
        {
                Move();
                
                //Falling down
                _velocity.y += gravity * Time.deltaTime;

                //Jump
                _characterController.Move(_velocity * Time.deltaTime);
        }

        public void SetSpeedValues(float newWalkSpeed, float newSprintSpeed)
        {
                speed = newWalkSpeed;
                sprintSpeed = newSprintSpeed;
        }

        public void SetMaxJumpHeight(float newMaxHeight)
        {
                jumpHeight = newMaxHeight;
        }

        private void OnSprintButtonDown()
        {
                _speedToUse = sprintSpeed;
        }

        private void OnSprintButtonUp()
        {
                _speedToUse = speed;
        }

        private void Move()
        {
                if (IsGrounded && _velocity.y < 0)
                {
                        _velocity.y = -2f;
                }

                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");
                
                Vector3 moveDirection = transform.right * x + transform.forward * z;

                _velocity.x = moveDirection.x;
                _velocity.z = moveDirection.z;
                
                _characterController.Move(moveDirection * _speedToUse * Time.deltaTime);
                
                if (_lastPosition != transform.position && IsGrounded)
                {
                        IsMoving = true;
                }
                else
                {
                        IsMoving = false;
                }

                _lastPosition = transform.position;
        }

        private void Jump()
        {
                if (IsGrounded)
                { 
                        _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
        }
}