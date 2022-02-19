using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WaterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    public event Action<int, int> OnHealthChanged;

    private int currentHealth;

    private void Start()
    {
        SetHealth(maxHealth);
    }
    private void SetHealth(int value)
    {
        currentHealth = value;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
    public void DealDamage(int damageAmount)
    {
        SetHealth(Mathf.Max(currentHealth - damageAmount, 0));
    }

    
}
