using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private float groundDistance = 0.4f;

    [SerializeField] private LayerMask groundMask;

    public Vector3 groundPos;
    
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
        Ray ray = new Ray(transform.position,Vector3.down );
        
        if (Physics.Raycast(ray ,out RaycastHit  hitInfo, 10,groundMask))
        {
            groundPos = hitInfo.point;
            IsGrounded = Vector3.Distance(transform.position, groundPos) < groundDistance;
        }

        
    }
}
