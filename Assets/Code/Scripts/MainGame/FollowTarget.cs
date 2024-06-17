using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowTarget : MonoBehaviour
{
    public FollowTargetType followTargetType;

    public int rotationOffset = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateToTarget();
    }



    public void RotateToTarget()
    {
        switch (followTargetType)
        {
            case FollowTargetType.Player:
                // Find the player by tag
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    Vector3 direction = player.transform.position - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotationOffset;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
                }
                break;
            case FollowTargetType.Mouse:
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 directionMouse = mousePos - transform.position;
                float angleMouse = Mathf.Atan2(directionMouse.y, directionMouse.x) * Mathf.Rad2Deg + rotationOffset;
                Quaternion rotationMouse = Quaternion.AngleAxis(angleMouse, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotationMouse, 5 * Time.deltaTime);
                break;
            default:
                break;
        }
    }
    
}

public enum FollowTargetType
{
    Player,
    Mouse
}
