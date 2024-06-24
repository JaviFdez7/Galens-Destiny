using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public float moveSpeed = 2f; // Constant move speed of the enemy
    public float attackRange = 1f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    private int currentHealth;
    public int maxHealth = 100;

    private GameObject player;
    private Rigidbody2D rb;
    private bool canAttack = true;
    private bool canMove = true;
    [Range(0, 1)]
    public float dropChance = 0.2f;

    public HealthEnemyBar healthEnemyBar;

    public List<GameObject> dropitems = new List<GameObject>();

    public event Action<int> OnHealthChanged;



    void Start()
    {
        currentHealth = maxHealth;
        healthEnemyBar.InitializeHealthBar(maxHealth, currentHealth);
  
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Calculate the direction towards the player.
        Vector2 directionToPlayer = ((Vector2)player.transform.position - rb.position);

        // Move the enemy towards the player with the constant speed.
        if (canMove)
            rb.velocity = directionToPlayer.normalized * moveSpeed;

        // Check the distance to the player and attack if within the attack range.
        float distanceToPlayer = directionToPlayer.magnitude;
        if (distanceToPlayer <= attackRange && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        // Put your attack logic here.
        // For example, you can deal damage to the player or trigger any other action.
        Debug.Log("Enemy attacking!");
        // Deal damage to the player (assuming the player has a Health script).
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            SoundMainManager.instance.PlayHit();
            playerHealth.TakeDamage(attackDamage,Vector2.zero);
        }

        // Set a cooldown before the enemy can attack again.
        canAttack = false;
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    public void TakeDamage(int damageAmount, Vector2 damageDirection)
    {
        currentHealth -= damageAmount;
        // Invoke the event to notify the health bar about the change in health.
        OnHealthChanged?.Invoke(currentHealth);
        SoundMainManager.instance.PlayMetalicHit();
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Knockback(damageDirection); // Invoke the knockback immediately with direction
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        // Invoke the event to notify the health bar about the change in health.
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void Die()
    {
        // Put your death logic here.
        // For example, you can play a death animation, disable the enemy, etc.
        Debug.Log("Enemy died!");
        DropItems.Drop(this.transform, dropChance, dropitems);
        Destroy(gameObject);
    }



    void Knockback(Vector2 direction, float force = 20f)
    {
        if (!canMove) return;
        canMove = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        Invoke("ResetCanMove", 1f); // Reset canMove to true after 1 second
    }

    void ResetCanMove()
    {
        canMove = true;
    }


}
