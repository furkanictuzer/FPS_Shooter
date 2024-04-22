using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private AmmoUIController ammoUIController;
    [Space]
    [Header("Player Bars")]
    [SerializeField] private PlayerBarController playerHpBarController;
    [SerializeField] private PlayerXpUIController playerXpUIController;
    [Space] 
    [SerializeField] private TextController highestScoreController;

    public void SetPlayerHp(float percent)
    {
        playerHpBarController.SetPercent(percent);
    }

    public void SetPlayerXp(float percent, int level)
    {
        playerXpUIController.SetLevelInfo(percent, level);
    }

    public void SetHighestScore(string str)
    {
        highestScoreController.SetText(str);
    }
}
