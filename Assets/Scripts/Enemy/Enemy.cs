using UnityEngine;

public class Enemy : DamageableObject
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private BarController barController;

    public int xpAwarded = 10;
    
    private void Start()
    {
        SetHp(maxHp);
    }
    
    private void OnEnable()
    {
        OnTakeDamage += SetHpBar;
        
        OnDead += OnDeath;
    }

    private void OnDisable()
    {
        OnTakeDamage -= SetHpBar;
        
        OnDead -= OnDeath;
    }

    private void OnDeath()
    {
        LevelController.instance.AddKillScore();
        
        enemyController.ChangeState(new DeadState());
        
        GiveXPs();
    }

    private void GiveXPs()
    {
        LevelController.instance.currentPlayer.PlayerLevelController.EarnExperiencePoint(xpAwarded);
    }

    private void SetHpBar()
    {
        float percent = (float)CurrentHp / maxHp;

        barController?.SetPercent(percent);
    }
}
