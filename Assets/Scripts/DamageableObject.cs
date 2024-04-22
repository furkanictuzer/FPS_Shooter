using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected int minHp = 0;
    [SerializeField,Range(0,1)] protected float initialHpPercent = 1;
    public int CurrentHp { get; private set; }
    
    public event Action OnTakeDamage;
    public event Action HpAmountChanged;
    public event Action OnDead;

    public bool IsDead { get; private set; }

    private void Awake()
    {
        CurrentHp = (int)(initialHpPercent * maxHp);
    }

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

    public void SetMaxHealth(int newMaxHealth)
    {
        maxHp = newMaxHealth;
    }

    public void Heal(int healedHp)
    {
        AddHp(healedHp);
    }

    private void AddHp(int amount)
    {
        CurrentHp = Mathf.Clamp(CurrentHp + amount, minHp, maxHp);
        
        HpAmountChanged?.Invoke();
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
}
