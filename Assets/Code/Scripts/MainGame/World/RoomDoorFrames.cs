using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorFrames : MonoBehaviour
{
    public GameObject doorFrameHoleUp;
    public GameObject doorFrameHoleRight;
    public GameObject doorFrameHoleDown;
    public GameObject doorFrameHoleLeft;


    public List<IUnlockable> doors = new();

/// <summary>
/// Open the door frame inside a room (this is executed before the game starts)
/// Then set the door prefab in the hole
/// </summary>
    public void RemoveWallAndSetDoor(DoorData door)
    {
        GameObject HorizontalDoorPrefab = Resources.Load<GameObject>("Prefabs/Rooms/HorizontalDoor");
        Quaternion rotation = Quaternion.identity;
        Vector3 position = Vector3.zero;
        switch (door.direction)
        {
            case DoorDirection.UP:
                doorFrameHoleUp.SetActive(false);
                rotation = Quaternion.identity;
                position = doorFrameHoleUp.transform.position;
                break;
            case DoorDirection.RIGHT:
                doorFrameHoleRight.SetActive(false);
                rotation = Quaternion.Euler(0, 0, -90);
                position = doorFrameHoleRight.transform.position;
                break;
            case DoorDirection.DOWN:
                doorFrameHoleDown.SetActive(false);
                rotation = Quaternion.Euler(0, 0, 180);
                position = doorFrameHoleDown.transform.position;
                break;
            case DoorDirection.LEFT:
                doorFrameHoleLeft.SetActive(false);
                rotation = Quaternion.Euler(0, 0, 90);
                position = doorFrameHoleLeft.transform.position;
                break;
        }
        GameObject doorGo = Instantiate(HorizontalDoorPrefab, position, rotation, this.transform);
        doorGo.GetComponent<Door>().key = door.key;
        doors.Add(doorGo.GetComponent<IUnlockable>());
    }


    public void UnlockRoom()
    {
        foreach (var door in doors)
        {
            door.Unlock();
        }
    }
}

public enum DoorDirection
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}