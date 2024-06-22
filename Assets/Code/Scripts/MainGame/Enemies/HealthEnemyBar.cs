using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnemyBar : MonoBehaviour
{
    public Slider slider;
    public static HealthEnemyBar instance;

    public IDamageable damageable;


    private void Start()
    {
        damageable = GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.OnHealthChanged += ChangeCurrentHealth;
        }
    }


    public void ChangeMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }

    public void InitializeHealthBar(int maxHealth, int currentHealth)
    {
        ChangeMaxHealth(maxHealth);
        ChangeCurrentHealth(currentHealth);
    }
}
