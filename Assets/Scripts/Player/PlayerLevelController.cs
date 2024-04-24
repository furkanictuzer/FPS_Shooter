using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLevelController : MonoBehaviour
{
    #region Properties

    [SerializeField] private Player player;
    [Space]
    [SerializeField] private PlayerLevelXPPointInfo levelXpPointInfo;
    
    public event Action ExperiencePointsEarned;
    public event Action<int> LevelIncreased;
    
    private int _currentXpPoint = 0;
    private float xpPercent => (float) _currentXpPoint / NeededExpPoint;

    private int NeededExpPoint => levelXpPointInfo.GetNeededPoint(CurrentLevel - 1);

    public int CurrentLevel { get; private set; } = 1;

    #endregion

    #region Unity Events

    private void Start()
    {
        UIManager.instance.SetPlayerXp(xpPercent, CurrentLevel);
    }

    #endregion

    #region Methods

    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
    }
    
    public void EarnExperiencePoint(int earnedPointAmount)
    {
        ExperiencePointsEarned?.Invoke();
        
        _currentXpPoint += earnedPointAmount;

        CheckLevelUp();
        
        UIManager.instance.SetPlayerXp(xpPercent, CurrentLevel);
    }

    private void CheckLevelUp()
    {
        bool canLevelUp = _currentXpPoint >= NeededExpPoint;
        
        if (canLevelUp)
        {
            LevelUp();
        }
    }

    private void LevelUp(int numberOfLevel = 1)
    {
        TalentController.instance.AddTalentPoint();
        
        _currentXpPoint -= NeededExpPoint;
        
        CurrentLevel += numberOfLevel;
        
        LevelIncreased?.Invoke(CurrentLevel);
        
        EventManager.OnPlayerLevelUp(CurrentLevel);
        
        CheckLevelUp();
    }

    #endregion
}
