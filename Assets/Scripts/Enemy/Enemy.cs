using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : DamageableObject
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private BarController barController;

    public int xpAwarded = 10;
    
    private void Start()
    {
        SetHpBar();
    }
    
    private void OnEnable()
    {
        OnTakeDamage += SetHpBar;
        
        OnDead += GiveXPs;
        OnDead += OnThisDestroy;
    }

    private void OnDisable()
    {
        OnTakeDamage -= SetHpBar;
        
        OnDead -= GiveXPs;
        OnDead -= OnThisDestroy;
    }

    private void OnThisDestroy()
    {
        LevelController.instance.AddKillScore();
        enemyController.ChangeState(new DieState());
    }

    private void GiveXPs()
    {
        LevelController.instance.CurrentPlayer.PlayerLevelController.EarnExperiencePoint(xpAwarded);
    }

    private void SetHpBar()
    {
        float percent = (float)CurrentHp / maxHp;

        barController.SetPercent(percent);
    }
}
