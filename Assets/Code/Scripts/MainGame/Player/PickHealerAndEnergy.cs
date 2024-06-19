using UnityEngine;

public class PickHealXpAndEnergy : MonoBehaviour
{
    // Start is called before the first frame update
    public int healAmount = 0;
    public int energyAmount = 0;
    public int expAmount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Energy energy = other.GetComponent<Energy>();
            if (energy != null && energyAmount > 0)
            {
                energy.AddEnergy(energyAmount);
                Debug.Log("Player picked up " + energyAmount + " energy");
            }
            IDamageable heal = other.GetComponent<IDamageable>();
            if (heal != null && healAmount > 0)
            {
                heal.Heal(healAmount);
                Debug.Log("Player picked up " + healAmount + " health");
            }
            Experience exp = other.GetComponent<Experience>();
            if (exp != null && expAmount > 0) 
            {
                exp.IncreaseExp(expAmount);
                Debug.Log("Player picked up " + expAmount + " experience");
            }
                Destroy(gameObject);
        }
    }
}
