using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLevelController : MonoBehaviour
{
    [SerializeField] private Player player;
    [Space]
    [SerializeField] private PlayerLevelXPPointInfo levelXpPointInfo;
    
    public event Action ExperiencePointsEarned;
    public event Action<int> LevelIncreased;
    
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private int _currentXPPoint = 0;
    private float xpPercent => (float) _currentXPPoint / NeededExpPoint;

    public int NeededExpPoint => levelXpPointInfo.GetNeededPoint(_currentLevel - 1);

    private void Start()
    {
        UIManager.instance.SetPlayerXp(xpPercent, _currentLevel);
    }

    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
    }
    
    public void EarnExperiencePoint(int earnedPointAmount)
    {
        ExperiencePointsEarned?.Invoke();
        
        _currentXPPoint += earnedPointAmount;

        CheckLevelUp();
        
        UIManager.instance.SetPlayerXp(xpPercent, _currentLevel);
    }

    private void CheckLevelUp()
    {
        bool canLevelUp = _currentXPPoint >= NeededExpPoint;
        
        if (canLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp(int numberOfLevel = 1)
    {
        _currentXPPoint -= NeededExpPoint;
        
        _currentLevel += numberOfLevel;
        
        LevelIncreased?.Invoke(_currentLevel);
        
        CheckLevelUp();
    }
}
