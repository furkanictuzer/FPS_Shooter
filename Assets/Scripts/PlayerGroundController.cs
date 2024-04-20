using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundController : MonoBehaviour
{
    [SerializeField] private float groundDistance = 0.4f;

    [SerializeField] private LayerMask groundMask;
    
    private Rigidbody _rigidbody;
    private SphereCollider _collider;

    public bool IsGrounded;// { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }
}
