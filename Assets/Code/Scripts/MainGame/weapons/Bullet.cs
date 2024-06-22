using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    private Vector3 target;

    private int damage = 5;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

[SerializeField]
    private List<string> tagsToIgnore = new();

    public void AddAllTagToIgnore(List<string> tagsToIgnore)
    {
        foreach (var tag in tagsToIgnore)
        {
            this.tagsToIgnore.Add(tag);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector2 direction = (Vector2)target - rb.position;
        direction.Normalize();
        rb.velocity = transform.up * 10;}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tagsToIgnore !=null && tagsToIgnore.Count!=0)
        {
            foreach (var tag in tagsToIgnore)
            {
                if (collision.gameObject.CompareTag(tag))
                {
                    Debug.Log("Ignoring collision with: " + collision.gameObject.name);
                    return;
                }
            }
        }
        Vector2 direction = collision.transform.position - transform.position;
        direction=direction.normalized;
        IDamageable damagable = collision.gameObject.GetComponent<IDamageable>();
        if (damagable != null)
        {
            MakeDamage(damagable,direction);
            Destroy(gameObject);
        }
        damagable = collision.gameObject.GetComponentInParent<IDamageable>();
        if (damagable != null)
        {
            MakeDamage(damagable,direction);
            Destroy(gameObject);
        }

    }

    private void MakeDamage(IDamageable damagable, Vector2 direction)
    {
            
            damagable.TakeDamage(this.damage, direction);
    }
}
