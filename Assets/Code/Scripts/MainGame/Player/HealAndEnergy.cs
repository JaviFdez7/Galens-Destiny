using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAndEnergy : MonoBehaviour
{
    // Start is called before the first frame update
    public int healAmount = 0;
    public int energyAmount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Energy energy = other.GetComponent<Energy>();
            if (energy != null)
            {
                energy.AddEnergy(energyAmount);
                Debug.Log("Player picked up " + energyAmount + " energy");
            }
            Health heal = other.GetComponent<Health>();
            if (heal != null)
            {
                heal.Heal(healAmount);
                Debug.Log("Player picked up " + healAmount + " health");
            }
                Destroy(gameObject);
        }
    }
}
