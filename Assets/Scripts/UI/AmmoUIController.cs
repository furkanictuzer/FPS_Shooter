using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AmmoUIController : TextController
{
    [SerializeField] private GameObject reloadInformObject;
    private void OnEnable()
    {
        EventManager.TotalBulletAmountChanged += SetAmmoInfo;
    }

    private void OnDisable()
    {
        EventManager.TotalBulletAmountChanged -= SetAmmoInfo;
    }

    private void SetAmmoInfo(int bulletInMagazine, int spareBullet)
    {
        CheckReloadInfoObject(bulletInMagazine > 0);
        
        StringBuilder builder = new StringBuilder();

        builder.Append(bulletInMagazine);
        builder.Append("/");
        builder.Append(spareBullet);
        
        SetText(builder.ToString());
    }

    private void CheckReloadInfoObject(bool hasAmmo)
    {
        reloadInformObject.SetActive(!hasAmmo);
    }
}
