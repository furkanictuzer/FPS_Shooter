using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int minHp = 0;
    
    public int CurrentHp { get; private set; }
    
    public event Action<int> OnTakeDamage;
    public event Action OnDead;

    public void TakeDamage(int takenDamageAmount)
    {
        AddHp(-takenDamageAmount);
        
        OnTakeDamage?.Invoke(CurrentHp);
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
    }

    private void Died()
    {
        OnDead?.Invoke();
        Debug.Log("Object Died: " + name);
    }

    private bool CheckDead()
    {
        return CurrentHp <= minHp;
    }
}
