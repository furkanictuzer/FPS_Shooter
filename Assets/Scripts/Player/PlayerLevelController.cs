using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerLevelExpPointInfo levelExpPointInfo;

    public event Action ExperiencePointsEarned;
    public event Action<int> LevelIncreased;
    
    private int _currentLevel = 1;
    private int _currentExpPoint = 0;

    public int NeededExpPoint => levelExpPointInfo.GetNeededPoint(_currentLevel - 1);

    public void EarnExperiencePoint(int earnedPointAmount)
    {
        ExperiencePointsEarned?.Invoke();

        _currentExpPoint += earnedPointAmount;

        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        bool canLevelUp = _currentExpPoint >= NeededExpPoint;
        
        if (canLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp(int numberOfLevel = 1)
    {
        _currentExpPoint -= NeededExpPoint;
        
        _currentLevel += numberOfLevel;
        
        LevelIncreased?.Invoke(_currentLevel);
        
        CheckLevelUp();
    }
}
