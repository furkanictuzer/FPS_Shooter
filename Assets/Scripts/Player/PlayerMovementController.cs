﻿using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
        [SerializeField] private PlayerGroundController groundController;
        [Space]
        [SerializeField] private float speed = 12f;
        [SerializeField] private float gravity = -9.81f * 2;
        [SerializeField] private float jumpHeight = 3f;
        
        private CharacterController _characterController;
        
        [SerializeField] private Vector3 _velocity;
        private Vector3 _lastPosition;
        
        public bool IsMoving { get; private set; }

        private bool IsGrounded => groundController.IsGrounded;

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
        }

        private void Start()
        {
                InputController.instance.OnJumpPressed += Jump;
        }

        private void OnDestroy()
        {
                InputController.instance.OnJumpPressed -= Jump;
        }

        private void Update()
        {
                Move();
                
                //Falling down
                _velocity.y += gravity * Time.deltaTime;

                //Jump
                _characterController.Move(_velocity * Time.deltaTime);
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
                
                _characterController.Move(moveDirection * speed * Time.deltaTime);
                
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