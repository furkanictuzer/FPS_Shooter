using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerFiringController : MonoBehaviour
{
    [SerializeField] private PlayerInputController playerInputController;
    
    [SerializeField] private Transform firingPoint;
    
    [SerializeField] private LayerMask enemyLayer;
    
    [SerializeField] private float fireDistance = 50;
    
    [SerializeField] private Gun gun;

    [SerializeField] private int damageAmount;
    
    private Camera _mainCam;

    private int _pierceShot;
    public bool HasAmmo => gun.HasAmmo;
    public bool CanReload => gun.CanReload;

    private void Awake()
    {
        if (gun == null)
        {
            gun = GetComponentInChildren<Gun>();
        }
        
        _mainCam = Camera.main;
    }

    public void Reload()
    {
        gun.Reload();
    }

    public void AddBullet(int amount, out int residualAmmoAmount)
    {
        gun.AddBullet(amount, out residualAmmoAmount);
    }

    public void SetDamageAmount(int newDamageAmount)
    {
        damageAmount = newDamageAmount;
    }

    public void SetPierceShot(int newPierceShot)
    {
        _pierceShot = newPierceShot;
    }

    public void Fire()
    {
        Ray ray = new Ray(firingPoint.position, firingPoint.forward);
        bool isHit = Physics.Raycast(ray, out var hitInfo, fireDistance, enemyLayer);
        
        gun.Fire();
        
        if (isHit)
        {
            Enemy enemy = hitInfo.transform.gameObject.GetComponentInParent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
                Debug.Log("Hit Enemy");
            }
        }
    }
}
