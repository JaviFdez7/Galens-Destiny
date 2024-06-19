using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSkill : MonoBehaviour
{
    // Start is called before the first frame update
    public int healAmount = 0;
    public int energyAmount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO
            Destroy(gameObject);
        }
    }
}
