using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer = 2f;
    public float areaOfEffect = 3;
    public int damage = 75;
    public GameObject effect;

    void Update()
    {
        if (timer <= 0)
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                Vector2 direction = objectsToDamage[i].transform.position - transform.position;
                //If thag is envirometnt damage * 10
                if (objectsToDamage[i].CompareTag("Environment"))
                {
                    IDamageable damageable = objectsToDamage[i].GetComponent<IDamageable>();
                    damageable?.TakeDamage(damage * 10, direction.normalized);
                }
                else
                {
                    IDamageable damageable = objectsToDamage[i].GetComponent<IDamageable>();
                    if (damageable != null){
                        damageable.TakeDamage(damage, direction.normalized);
                    }else{
                        damageable = objectsToDamage[i].GetComponentInParent<IDamageable>();
                        damageable?.TakeDamage(damage, direction.normalized);
                    }
                }
            }
            SoundMainManager.instance.PlayExplosion();
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}
