using System;

public static class EventManager
{
    public static event Action GameStarted;
    public static event Action<int, int> TotalBulletAmountChanged;
    
    public static event Action<int> TalentPointChanged;

    public static event Action LevelFailed;

    public static event Action<int> PlayerLevelUp;
    
    public static void OnGameStarted()
    {
        GameStarted?.Invoke();
    }

    public static void OnTotalBulletAmountChanged(int bulletInMagazine, int spareBullet)
    {
        TotalBulletAmountChanged?.Invoke(bulletInMagazine, spareBullet);
    }

    public static void OnTalentPointChanged(int point)
    {
        TalentPointChanged?.Invoke(point);
    }

    public static void OnLevelFailed()
    {
        LevelFailed?.Invoke();
    }

    public static void OnPlayerLevelUp(int newLevel)
    {
        PlayerLevelUp?.Invoke(newLevel);
    }
}
