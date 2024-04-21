using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour
{
    [SerializeField] private Magazine magazine;
    
    [SerializeField] private int spareBulletAmount = 20;
    
    private int _maxAmountOfAmmo = 30;
    public bool HasAmmo => magazine.HasAmmo;
    public bool CanReload => spareBulletAmount > 0 && !magazine.IsFull;

    public int BulletSpaceAmount => _maxAmountOfAmmo - (spareBulletAmount + magazine.CurrentBulletAmount);
    
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

    public void AddBullet(int amount, out int residualAmmoAmount)
    {
        int oldSpareAmount = spareBulletAmount;
        
        spareBulletAmount = Mathf.Clamp(spareBulletAmount + amount,
            0,
            _maxAmountOfAmmo - magazine.CurrentBulletAmount);

        residualAmmoAmount = amount + oldSpareAmount - spareBulletAmount;
        
        EventManager.OnTotalBulletAmountChanged(magazine.CurrentBulletAmount, spareBulletAmount);
    }

    public void SetMaxBullet(int newSpareBulletAmount)
    {
        _maxAmountOfAmmo = newSpareBulletAmount;
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
