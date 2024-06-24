using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float attackRange = 1f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    public bool bulletFollowsPlayer = false;

    public GameObject bulletPrefab;
    public GameObject shootPoint;
    private GameObject player;
    private Rigidbody2D rb;
    private bool canAttack = true;
    private Animator animator;







    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Calculate the direction towards the player.
        Vector2 directionToPlayer = ((Vector2)player.transform.position - rb.position);
        float distanceToPlayer = directionToPlayer.magnitude;
        if (distanceToPlayer <= attackRange && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        SoundMainManager.instance.PlayShootEnemy();
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.target = player.transform.position;
        bulletScript.followsTarget = bulletFollowsPlayer;
        bulletScript.AddAllTagToIgnore(new List<string> { "EnemyCollider" });
        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }

        // Set a cooldown before the enemy can attack again.
        canAttack = false;
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

   


}
