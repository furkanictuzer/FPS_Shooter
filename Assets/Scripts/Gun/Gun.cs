using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    [SerializeField] private Magazine magazine;
    
    [SerializeField] private int spareBulletAmount = 20;

    public bool HasAmmo => magazine.HasAmmo;
    public bool CanReload => spareBulletAmount > 0;
    
    private void Start()
    {
        EventManager.OnTotalBulletAmountChanged(magazine.CurrentBulletAmount, spareBulletAmount);
    }

    public void Fire()
    {
        bool hasAmmo = HasAmmo;
        magazine.FireBullet();
        
        if (hasAmmo)
        {
            EventManager.OnTotalBulletAmountChanged(magazine.CurrentBulletAmount, spareBulletAmount);
        }
    }

    public void SetSpareBullet(int newSpareBulletAmount)
    {
        spareBulletAmount = newSpareBulletAmount;
    }
    
    public void Reload()
    {
        if (spareBulletAmount > 0)
        {
            magazine.Reload(ref spareBulletAmount);
        }

        EventManager.OnTotalBulletAmountChanged(magazine.CurrentBulletAmount, spareBulletAmount);
    }
}
