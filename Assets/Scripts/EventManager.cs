using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event Action<int, int> MagazineReloaded;
    public static event Action<int, int> TotalBulletAmountChanged;

    public static void OnMagazineReloaded(int bulletInMagazine, int spareBullet)
    {
        MagazineReloaded?.Invoke(bulletInMagazine, spareBullet);
    }

    public static void OnTotalBulletAmountChanged(int bulletInMagazine, int spareBullet)
    {
        TotalBulletAmountChanged?.Invoke(bulletInMagazine, spareBullet);
    }
}
