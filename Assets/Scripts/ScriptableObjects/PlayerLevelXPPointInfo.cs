using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Info/PlayerLevelXPPointInfo", fileName = "PlayerLevelXPPointInfo")]
public class PlayerLevelXPPointInfo : ScriptableObject
{
    [SerializeField] private List<int> neededExpPoints = new List<int>();

    public int GetNeededPoint(int levelIndex)
    {
        int clampedIndex = Mathf.Clamp(levelIndex, 0, neededExpPoints.Count - 1);

        return neededExpPoints[clampedIndex];
    }
}
