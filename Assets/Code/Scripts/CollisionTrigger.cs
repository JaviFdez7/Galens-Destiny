using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Needs to be in an object with a COLLIDER component with isTrigger ACTIVATED
public class ZoneDetection : MonoBehaviour
{
    [SerializeField] private string TagToDetect="Player";
    public IZoneTrigger linkedScript;
    private bool Inside = false ;
    public bool IsInside(){ return Inside;}
    private void OnTriggerEnter2D(Collider2D EnteringObject) {
        
        if(EnteringObject.CompareTag(TagToDetect) ) 
        {
            linkedScript.SetInsideZone(true);
        }
    }
    private void OnTriggerExit2D(Collider2D ExitingObject) {
        
        if(ExitingObject.CompareTag(TagToDetect) ) 
        {
            linkedScript.SetInsideZone(false);
        }
    }
}

public interface IZoneTrigger
{
    void SetInsideZone(Boolean InsideZone);
}