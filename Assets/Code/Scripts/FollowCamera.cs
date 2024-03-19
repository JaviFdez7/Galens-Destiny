using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject target;

    private float targetPosX;
    private float targetPosY;

    private float posX;
    private float posY;

    public float rightMax;
    public float leftMax;
    public float highMax;
    public float highMin;

    public float speed;
    public bool on = true;
    private float cameraZ = -500;


    // Use this for initialization
    void Awake()
    {
        posX = targetPosX + leftMax;
        posY = targetPosY + highMin;
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX,posY,transform.position.z),1);

    }

    void MoveCam()
    {
        if(on)
        {
            if(target)
            {
                targetPosX = target.transform.position.x;
                targetPosY = target.transform.position.y;

                if(targetPosX > leftMax && targetPosX < rightMax)
                {
                    posX = targetPosX;
                }
                
                if(targetPosY < highMax && targetPosY > highMin)
                {
                    posY = targetPosY;
                }

                transform.position = Vector3.Lerp(transform.position, new Vector3(posX,posY,cameraZ), speed * Time.deltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
    }
}
