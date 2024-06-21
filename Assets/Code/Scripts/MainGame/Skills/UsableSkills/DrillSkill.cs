using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DrillSkill : MonoBehaviour, IExecuteCommand
{

    public int damageAmount = 2;
    private Collider2D areaCollider;

    private KeyCode keyCode = KeyCode.Mouse1;
    private bool holdingKey = false;
    private Animator animator;

    void Awake()
    {
        areaCollider = GetComponent<Collider2D>();
        if (areaCollider == null)
        {
            Debug.LogError("No Collider attached to the GameObject.");
        }
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        if (Input.GetKeyUp(keyCode))
        {
            holdingKey = false;
            animator.SetFloat("DrillSpeed", 1f);
        }
        Drill();
    }



    public void Execute(){
        holdingKey = true;
    }


    public void Drill()
    {
        if(!holdingKey) return;
        animator.SetFloat("DrillSpeed", 4f);
        if (areaCollider == null)
        {
            Debug.LogError("No Collider found for damage area.");
            return;
        }

        // Ensure that areaCollider is a Collider2D
        Collider2D[] colliders = new Collider2D[10];
        Physics2D.OverlapCollider(areaCollider, new ContactFilter2D().NoFilter(),colliders);
        foreach (Collider2D collider in colliders)
        {
            if (collider == null) continue;
            Debug.Log("Collided with: " + collider.name);
            if (collider.CompareTag("Player")) continue;
            IDamageable damageable = collider.GetComponentInParent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount, Vector2.zero);
            }
        }
    }
}
