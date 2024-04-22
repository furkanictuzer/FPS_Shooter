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

    private int _pierceShot = 2;
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
        Vector3 origin = firingPoint.position;
        Vector3 direction = firingPoint.forward;
        
        Ray ray = new Ray(origin, direction);

        RaycastHit[] hits = Physics.RaycastAll(origin, direction, fireDistance, enemyLayer);
        
        bool isHit = hits.Length > 0;
        gun.Fire();
        
        if (isHit)
        {
            List<Enemy> enemies = GetEnemyList(hits);

            foreach (var enemy in enemies)
            {
                enemy.TakeDamage(damageAmount);
                Debug.Log("Hit Enemy : " + enemy.name);
            }
        }
    }

    private List<Enemy> GetEnemyList(RaycastHit[] hits)
    {
        List<Enemy> output = new List<Enemy>();
        
        foreach (var hitInfo in hits)
        {
            if (output.Count < _pierceShot)
            {
                Enemy enemy = hitInfo.transform.gameObject.GetComponentInParent<Enemy>();

                if (enemy != null)
                {
                    output.Add(enemy);
                }
            }
            else
            {
                break;
            }
        }

        return output;
    }
}
