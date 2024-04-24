using System;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    #region Properties

    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected int minHp = 0;
    public int CurrentHp { get; private set; }
    
    public event Action OnTakeDamage;
    public event Action HpPercentChanged;
    public event Action OnDead;

    public bool IsDead { get; protected set; }

    #endregion

    #region Methods

    public virtual void TakeDamage(int takenDamageAmount)
    {
        if (IsDead)
        {
            return;
        }
        AddHp(-takenDamageAmount);
        
        OnTakeDamage?.Invoke();
        Debug.Log("Object Took Damage(" + takenDamageAmount + "): " + name);
        bool isDead = CheckDead();

        if (isDead)
        {
            Died();
        }
    }

    public void SetHp(int newHp)
    {
        CurrentHp = Mathf.Clamp(newHp, 0, maxHp);
        
        CalculateHpPercent();
        
        HpPercentChanged?.Invoke();
    }
    
    public void SetMaxHealth(int newMaxHealth)
    {
        maxHp = newMaxHealth;
        
        CalculateHpPercent();
        
        HpPercentChanged?.Invoke();
    }

    public void Heal(int healedHp)
    {
        AddHp(healedHp);
    }

    private void CalculateHpPercent()
    {
    }

    private void AddHp(int amount)
    {
        SetHp(CurrentHp + amount);
        
        HpPercentChanged?.Invoke();
    }

    private void Died()
    {
        if (IsDead)
        {
            return;
        }
        
        OnDead?.Invoke();
        IsDead = true;
        Debug.Log("Object Died: " + name);
    }

    private bool CheckDead()
    {
        return CurrentHp <= minHp;
    }

    #endregion
}
