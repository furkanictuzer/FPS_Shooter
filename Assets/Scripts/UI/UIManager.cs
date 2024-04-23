using System;
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
    [SerializeField] private TextController talentPointUI;
    [SerializeField] private TextController ammoCapacity;
    [SerializeField] private TextController killScore;
    private void Start()
    {
        SetTalentPoint(TalentController.instance.TalentPoint);
    }

    private void OnEnable()
    {
        EventManager.TalentPointChanged += SetTalentPoint;
    }

    public void OnDisable()
    {
        EventManager.TalentPointChanged -= SetTalentPoint;
    }

    public void SetTalentPoint(int point)
    {
        talentPointUI.SetText(point.ToString());
    }

    public void SetKillScore(int score)
    {
        killScore.SetText(score.ToString());
    }
    
    public void SetAmmoCapacity(string str)
    {
        ammoCapacity.SetText(str);
    }
    
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
