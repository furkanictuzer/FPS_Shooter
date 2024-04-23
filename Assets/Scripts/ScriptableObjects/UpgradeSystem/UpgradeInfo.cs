using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info/UpgradeInfo", fileName = "UpgradeInfo")]
public class UpgradeInfo : ScriptableObject
{
    [SerializeField] private UpgradeType upgradeType;
    
    public string upgradeName;
    
    public List<UpgradeListInfo> values = new List<UpgradeListInfo>();

    public UpgradeType GetUpgradeType()
    {
        return upgradeType;
    }
    
    public UpgradeListInfo GetValue(int level)
    {
        int index = Mathf.Clamp(level - 1, 0, values.Count);

        return values[index];
    }
    
    public bool HasLevelToUpgrade(int level, out UpgradeListInfo nextInfo)
    {
        nextInfo = null;

        int index = level - 1;
        int nextIndex = level;
        
        if (values.Count <= nextIndex)
        {
            return false;
        }
        else
        {
            nextInfo = values[nextIndex];
            return true;
        }
    }
}

[Serializable]
public class UpgradeListInfo
{
    public List<float> values = new List<float>();
    public int requiredPoint = 1;
}
