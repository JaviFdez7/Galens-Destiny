using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IDamageable, IUnlockable
{
    Animator animator;

    private bool godMode = true;
    private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

        public void Unlock()
    {
        this.godMode = false;
    }

    public void RemoveHealth(int amount)
    {
        if (currentHealth - amount < 0)
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage, Vector2 direction)
    {
        if (godMode)
            return;
        animator.Play("TakeDamage");
        RemoveHealth(damage);
        
    }

    private void Die()
    {
        animator.Play("Die");
        Destroy(gameObject, 0.5f);
    }



}

