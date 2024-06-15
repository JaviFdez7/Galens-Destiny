using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float DestanceToTargetToDestroy = 0.1f;

    private Vector3 target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target) < DestanceToTargetToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damagable))
        {
            Vector2 direction = collision.transform.position - transform.position;
            damagable.TakeDamage(10, direction);
        }

        Destroy(gameObject);
    }
}
