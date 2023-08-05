using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        if (currentHealth <= 0f)
        {
            Die();
            return;
        }
        currentHealth -= damageAmount;
        Debug.Log(currentHealth)

    }

    private void Die()
    {
        // Here you can add logic for what happens when the player dies.
        // For example, restart the level or show a game over screen.
        Debug.Log("Player died!");
        // You may want to disable player controls, show a game over screen, etc.
    }
}
