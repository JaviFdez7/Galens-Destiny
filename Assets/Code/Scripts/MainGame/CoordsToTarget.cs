using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordsToTarget : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.transform.position;
            this.transform.position = targetPosition;
        }
        
    }
}
