using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    void Start()
    {
        HealthBar.instance.InitializeHealthBar(PlayerData.instance.maxHealth, PlayerData.instance.currentHealth);
    }

    private void Update()
    {
        UIText();
    }

    public void TakeDamage(int damageAmount, Vector2 direction)
    {

        PlayerData.instance.currentHealth -= damageAmount;
        
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
        HealthBar.instance.ChangeCurrentHealth(PlayerData.instance.currentHealth);
    }

    public void Die()
    {
        // Here you can add logic for what happens when the player dies.
        // For example, restart the level or show a game over screen.
        Debug.Log("Player died!");
        // You may want to disable player controls, show a game over screen, etc.
    }

    public TextMeshProUGUI currentHealthBarMaxHealth;

    public void UIText()
    {
        currentHealthBarMaxHealth.text = "" + PlayerData.instance.currentHealth + " / " + PlayerData.instance.maxHealth;
    }

}
