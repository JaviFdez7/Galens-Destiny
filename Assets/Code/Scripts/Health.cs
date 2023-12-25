using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.InitializeHealthBar(currentHealth);
    }

    public void TakeDamage(float damageAmount)
    {

        currentHealth -= damageAmount;
        
        healthBar.ChangeCurrentHealth(currentHealth);

        Debug.Log(currentHealth);
        if (currentHealth <= 0f)
        {
            Die();
            return;
        }

    }

    private void Die()
    {
        // Here you can add logic for what happens when the player dies.
        // For example, restart the level or show a game over screen.
        Debug.Log("Player died!");
        // You may want to disable player controls, show a game over screen, etc.
    }
}
