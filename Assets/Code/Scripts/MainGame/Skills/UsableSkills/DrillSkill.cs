using Unity.VisualScripting;
using UnityEngine;

public class DrillSkill : MonoBehaviour, IExecuteCommand
{

    public int damageAmount = 5;
    private MappeableInput input;
    private Collider2D areaCollider;
    private void Start()
    {
        input = new MappeableInput();
    }

    void Awake()
    {
        areaCollider = GetComponent<Collider2D>();
        if (areaCollider == null)
        {
            Debug.LogError("No Collider attached to the GameObject.");
        }
    }

    public void Execute()
    {
        if (areaCollider == null)
        {
            Debug.LogError("No Collider found for damage area.");
            return;
        }

        // Ensure that areaCollider is a Collider2D
        Collider2D[] colliders = Physics2D.OverlapBoxAll(areaCollider.bounds.center, areaCollider.bounds.size, areaCollider.transform.eulerAngles.z);
        foreach (Collider2D collider in colliders)
        {
            Debug.Log("Collided with: " + collider.name);
            IDamageable damageable = collider.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount, Vector2.zero);
            }
        }
    }
}
