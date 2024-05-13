using UnityEngine;

public class EnemyController : MonoBehaviour
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

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Disable collision response
    }

    void FixedUpdate()
    {
        // Calculate the direction towards the player.
        Vector2 directionToPlayer = ((Vector2)player.transform.position - rb.position);

        // Move the enemy towards the player with the constant speed.
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
            playerHealth.TakeDamage(attackDamage);
        }

        // Set a cooldown before the enemy can attack again.
        canAttack = false;
        Invoke("ResetAttack", attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
            Destroy(gameObject);
    }
}
