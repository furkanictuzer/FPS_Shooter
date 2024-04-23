using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Speed=0,
    MaxJumpHeight=1,
    MaximumHp=2,
    GunDamageAmount=3,
    AmmoCapacity=4,
    PierceShot=5
}
public class UpgradeController : Singleton<UpgradeController>
{
    [SerializeField] private LevelController levelController;
    //[SerializeField] private List<UpgradeInfo> upgradeInfoList = new List<UpgradeInfo>();
    
    //private Dictionary<UpgradeType, UpgradeInfo> _upgradeMap = new Dictionary<UpgradeType, UpgradeInfo>();

    private Player CurrentPlayer => levelController.currentPlayer;

/*
    public bool HasLevelToUpgrade(UpgradeType type, int level, out UpgradeListInfo info)
    {
        info = null;
        if (_upgradeMap[type].values.Count <= level )
        {
            return false;
        }
        else
        {
            info = _upgradeMap[type].values[level - 1];
            return true;
        }
    }*/
    
    public void Upgrade(UpgradeType type, List<float> values)
    {
        // if (!_upgradeMap.ContainsKey(type))
        // {
        //     Debug.Log("This type does not assigned.");
        //     return;
        // }

        //List<float> values = _upgradeMap[type].GetValue(newLevel).values;
        
        switch (type)
        {
            case UpgradeType.Speed:
                CurrentPlayer.PlayerMovementController.SetWalkSpeedValue(values[0]);
                CurrentPlayer.PlayerMovementController.SetSprintSpeedValue(values[1]);
                break;
            case UpgradeType.MaxJumpHeight:
                CurrentPlayer.PlayerMovementController.SetMaxJumpHeight(values[0]);
                break;
            case UpgradeType.MaximumHp:
                CurrentPlayer.SetMaxHealth((int)values[0]);
                break;
            case UpgradeType.GunDamageAmount:
                CurrentPlayer.PlayerFiringController.SetDamageAmount((int)values[0]);
                break;
            case UpgradeType.AmmoCapacity:
                UIManager.instance.SetAmmoCapacity(values[0].ToString());
                CurrentPlayer.PlayerFiringController.SetAmmoCapacity((int)values[0]);
                break;
            case UpgradeType.PierceShot:
                CurrentPlayer.PlayerFiringController.SetPierceShot((int)values[0]);
                break;

        }
    }
}
