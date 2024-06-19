using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyHolder keyHolder = other.GetComponent<KeyHolder>();
            if (keyHolder != null)
            {
                keyHolder.AddKey(id);
                Debug.Log("Player picked up key with id: " + id);
                Debug.Log("Player now has keys: " + string.Join(", ", keyHolder.keys));
                Destroy(gameObject);
            }
        }
    }
}
