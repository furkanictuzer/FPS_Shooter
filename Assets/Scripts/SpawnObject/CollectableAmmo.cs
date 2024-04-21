using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableAmmo : CollectableObject
{
    [SerializeField] private TextMeshPro bulletAmountInfo;
    
    public int collectableBulletAmount = 10;

    private void Start()
    {
        SetAmountInfoText();
    }

    public override void Collect(Player player)
    {
        PlayerFiringController firingController = player.PlayerFiringController;

        firingController.AddBullet(collectableBulletAmount, out int residualAmmoAmount);

        if (residualAmmoAmount > 0)
        {
            SetCollectableBulletAmount(residualAmmoAmount);
            
            return;
        }
        else
        {
            DestroyItself();
        }
    }

    private void SetCollectableBulletAmount(int amount)
    {
        collectableBulletAmount = amount;
            
        SetAmountInfoText();
    }

    private void SetAmountInfoText()
    {
        bulletAmountInfo.SetText(collectableBulletAmount.ToString());
    }
}
