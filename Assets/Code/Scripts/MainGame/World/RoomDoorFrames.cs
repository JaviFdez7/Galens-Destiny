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
    public void RemoveWallAndSetDoor(DoorDirection doorDirection)
    {
        GameObject HorizontalDoorPrefab = Resources.Load<GameObject>("Prefabs/Rooms/HorizontalDoor");
        GameObject currentDoorFrameHole = null;
        switch (doorDirection)
        {
            case DoorDirection.UP:
                doorFrameHoleUp.SetActive(false);
                Instantiate(HorizontalDoorPrefab, doorFrameHoleUp.transform.position, Quaternion.identity, transform);
                doors.Add(HorizontalDoorPrefab.GetComponent<IUnlockable>());
                break;
            case DoorDirection.RIGHT:
                doorFrameHoleRight.SetActive(false);
                Instantiate(HorizontalDoorPrefab, doorFrameHoleRight.transform.position, Quaternion.Euler(0, 0, 90), transform);
                doors.Add(HorizontalDoorPrefab.GetComponent<IUnlockable>());
                break;
            case DoorDirection.DOWN:
                doorFrameHoleDown.SetActive(false);
                Instantiate(HorizontalDoorPrefab, doorFrameHoleDown.transform.position, Quaternion.Euler(0, 0, 180), transform);
                doors.Add(HorizontalDoorPrefab.GetComponent<IUnlockable>());
                break;
            case DoorDirection.LEFT:
                doorFrameHoleLeft.SetActive(false);
                Instantiate(HorizontalDoorPrefab, doorFrameHoleLeft.transform.position, Quaternion.Euler(0, 0, 270), transform);
                doors.Add(HorizontalDoorPrefab.GetComponent<IUnlockable>());
                break;
        }
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