using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IUnlockable
{
    /// <summary>
    /// key id to unlock this door. -1 means no key is required
    /// </summary>
    public int key = -1;
    public bool isLocked = true;
    public DoorAnimations doorAnimations;


    private void Start()
    {
        doorAnimations = GetComponent<DoorAnimations>();
        GameObject doorLock = transform.Find("DoorLeftPanel").Find("DoorLock").gameObject;
        RemoveOrPaintLock(doorLock);
    }

    private void RemoveOrPaintLock(GameObject doorLock)
    {
        if (key == -1)
        {
            Destroy(doorLock);
        }
        else
        {
            doorLock.GetComponent<SpriteRenderer>().color = KeyHolder.GetKeyColor(key);
        }
    }
        public void Unlock()
    {
        isLocked = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<KeyHolder>(out var keyHolder))
            {
                Debug.Log("Player entered door trigger");
                if (PlayerIsBehindDoor(other.transform.position))
                {
                    Debug.Log("Player is behind door");
                    doorAnimations.OpenDoor();
                    return;
                }
                else if (keyHolder.HasKey(key) && !isLocked)
                {
                    Debug.Log("Player has key");
                    doorAnimations.OpenDoor();
                }
                else
                {
                    Debug.Log("Player cannot open door");
                    doorAnimations.PlayOpenFailAnim();
                }
            }

        }
    }

    private bool PlayerIsBehindDoor(Vector3 position)
    {
        // Local position is relative to the door. The door is facing up. The player is behind the door if the player's y position is greater than the door's y position
        Vector3 PlayerlocalPosition = transform.InverseTransformPoint(position);
        return PlayerlocalPosition.y > transform.localPosition.y;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimations.CloseDoor();
        }
    }






}

