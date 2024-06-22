using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointZone : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerData.instance.lastCheckPoint = collision.transform.position;
            Debug.Log("Player reached checkpoint at: " + collision.transform.position);
        }
    }
}
