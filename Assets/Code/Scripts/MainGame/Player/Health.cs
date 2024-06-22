using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action<int> OnHealthChanged;
    void Start()
    {
        HealthBar.instance.InitializeHealthBar(PlayerData.instance.maxHealth, PlayerData.instance.currentHealth);
        SkillData.instance.RegenerateCommands();
    }

    private void Update()
    {
        UIText();
    }

    public void TakeDamage(int damageAmount, Vector2 direction)
    {

        PlayerData.instance.currentHealth -= damageAmount;
        PlayerData.instance.currentHealth = Mathf.Clamp(PlayerData.instance.currentHealth, 0, PlayerData.instance.maxHealth);
        OnHealthChanged?.Invoke(PlayerData.instance.currentHealth);
        
        HealthBar.instance.ChangeCurrentHealth(PlayerData.instance.currentHealth);

        Debug.Log(PlayerData.instance.currentHealth);
        if (PlayerData.instance.currentHealth <= 0f)
        {
            Die();
            return;
        }

    }

    public void Heal(int healAmount)
    {
        PlayerData.instance.currentHealth += healAmount;
        PlayerData.instance.currentHealth = Mathf.Clamp(PlayerData.instance.currentHealth, 0, PlayerData.instance.maxHealth);
        OnHealthChanged?.Invoke(PlayerData.instance.currentHealth);
        HealthBar.instance.ChangeCurrentHealth(PlayerData.instance.currentHealth);
    }

    public void Die()
    {
        PlayerData.instance.currentHealth = PlayerData.instance.maxHealth;
        PlayerData.instance.currentEnergy = PlayerData.instance.maxEnergy;
        HealthBar.instance.ChangeCurrentHealth(PlayerData.instance.currentHealth);
        this.transform.position = PlayerData.instance.lastCheckPoint;
    }

    public TextMeshProUGUI currentHealthBarMaxHealth;


    public void UIText()
    {
        currentHealthBarMaxHealth.text = "" + PlayerData.instance.currentHealth + " / " + PlayerData.instance.maxHealth;
    }

}
