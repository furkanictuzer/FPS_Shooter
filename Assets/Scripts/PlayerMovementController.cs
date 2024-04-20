using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
        [SerializeField] private PlayerGroundController groundController;
        [Space]
        [SerializeField] private float speed = 12f;
        [SerializeField] private float gravity = -9.81f * 2;
        [SerializeField] private float jumpHeight = 3f;
        
        private CharacterController _characterController;
        
        private Vector3 _velocity;
        private Vector3 _lastPosition;
        
        private bool _isMoving;

        private bool IsGrounded => groundController.IsGrounded;

        private void Awake()
        {
                _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
                Move();
                
                CheckJump();
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

                _characterController.Move(moveDirection * speed * Time.deltaTime);
                
                if (_lastPosition != transform.position && IsGrounded)
                {
                        _isMoving = true;
                }
                else
                {
                        _isMoving = false;
                }

                _lastPosition = transform.position;
        }

        private void CheckJump()
        {
                //Check if player can jump
                if (Input.GetButtonDown("Jump") && IsGrounded)
                {
                        _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
                //Falling down
                _velocity.y += gravity * Time.deltaTime;

                //Jump
                _characterController.Move(_velocity * Time.deltaTime);

                
        }
}