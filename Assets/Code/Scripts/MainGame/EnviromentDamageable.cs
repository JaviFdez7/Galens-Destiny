using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentDamageable : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    public int health = 1000;
    public bool isDestructible = true;

    GameObject damagedEffect;

    public event Action<int> OnHealthChanged;

    public void TakeDamage(int damage, Vector2 direction)
    {
        if (!isDestructible) return;
        health -= damage;
        OnHealthChanged?.Invoke(health);
        Debug.Log("Enviroment "+gameObject.name+" Health: " + health);
        if (damagedEffect != null)
        {
            GameObject effect = Instantiate(damagedEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }


    public void Heal(int amount)
    {
        health += amount;
        OnHealthChanged?.Invoke(health);
    }
}
