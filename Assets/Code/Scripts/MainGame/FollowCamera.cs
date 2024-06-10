using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 5f; // Speed at which the camera follows
    private Transform player; // Reference to the player's transform

    private Camera cam; // Reference to the camera

    public Animator shakeAnimatior;

    private static List<Shake> screenShakes = new List<Shake>();


    public static void ScreenShake(float duration, float magnitude)
    {
        screenShakes.Add(new Shake(duration, magnitude));

    }
    public class Shake
    {
        public float duration;
        public float magnitude;

        public Shake(float duration, float magnitude)
        {
            this.duration = duration;
            this.magnitude = magnitude;
        }
    }




    void Start()
    {
        // Find the player by the tag "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found.");
        }

        // Get the camera component attached to this script
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("Script must be attached to a camera object.");
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (screenShakes.Count > 0)
        {
            ShakeCamera(screenShakes[0].duration, screenShakes[0].magnitude);
            screenShakes.RemoveAt(0);
        }

        if (Input.GetMouseButtonDown(0)){
            ScreenShake(0.2f, 0.2f);
        }

        // Get the mouse position in the world
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, cam.nearClipPlane));

        // Calculate the midpoint between the player and the mouse position
        Vector3 midpoint = (3*player.position + mousePosition) / 4f;

        // Smoothly move the camera to the midpoint
        Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(midpoint.x, midpoint.y, transform.position.z), followSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void ShakeCamera(float duration, float magnitude)
    {
        //animation
        shakeAnimatior.Play("ScreenShake");
    }
}
