using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    private Animator doorAnimator;

    private void Awake() {
        doorAnimator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        SoundMainManager.instance.PlayDoor();
        doorAnimator.SetBool("Open", true);
    }

    public void CloseDoor() {
        SoundMainManager.instance.PlayCloseDoor();
        doorAnimator.SetBool("Open", false);
    }

    public void PlayOpenFailAnim() {
        doorAnimator.SetTrigger("OpenFailed");
    }
}
