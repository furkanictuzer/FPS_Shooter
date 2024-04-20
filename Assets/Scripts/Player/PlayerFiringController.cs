using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiringController : MonoBehaviour
{
    [SerializeField] private Transform firingPoint;
    
    [SerializeField] private LayerMask enemyLayer;
    
    [SerializeField] private float fireDistance = 50;
    
    private Camera _mainCam;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Ray ray = new Ray(firingPoint.position, firingPoint.forward);
        bool isHit = Physics.Raycast(ray, out var hitInfo, fireDistance, enemyLayer);
        
        if (isHit)
        {
            Enemy enemy = hitInfo.transform.gameObject.GetComponentInParent<Enemy>();

            if (enemy != null)
            {
                Debug.Log("Hit Enemy");
            }
        }
    }
}
