using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Magazine : MonoBehaviour
{
    [SerializeField] private int ammoCapacity = 10;
    
    [SerializeField] private int currentBulletAmount = 0;

    public int AmmoCapacity => ammoCapacity;
    public int CurrentBulletAmount => currentBulletAmount;
    public bool HasAmmo => currentBulletAmount > 0;

    public bool IsFull => currentBulletAmount >= ammoCapacity;
    
    public void Reload(ref int bulletAmount)
    {
        int neededBullet = ammoCapacity - currentBulletAmount;
        int bulletToUse = bulletAmount > neededBullet ? neededBullet : bulletAmount;

        bulletAmount -= bulletToUse;
        
        currentBulletAmount += bulletToUse;
    }

    public void FireBullet()
    {
        if (HasAmmo)
        {
            currentBulletAmount -= 1;
        }
    }
}
