using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorFrames : MonoBehaviour
{
    public GameObject doorFrameHoleUp;
    public GameObject doorFrameHoleRight;
    public GameObject doorFrameHoleDown;
    public GameObject doorFrameHoleLeft;

    public IUnlockable[] doors;

/// <summary>
/// Open the door frame inside a room (this is executed before the game starts)
/// These are the walls to remove if a door is placed
/// 0 - top
/// 1 - right
/// 2 - bottom
/// 3 - left
/// </summary>
    public void OpenFrame(DoorType doorType)
    {
        switch (doorType)
        {
            case DoorType.UP:
                doorFrameHoleUp.SetActive(false);
                break;
            case DoorType.RIGHT:
                doorFrameHoleRight.SetActive(false);
                break;
            case DoorType.DOWN:
                doorFrameHoleDown.SetActive(false);
                break;
            case DoorType.LEFT:
                doorFrameHoleLeft.SetActive(false);
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

public enum DoorType
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}