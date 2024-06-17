using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



// Needs to be in an object with a COLLIDER component with isTrigger ACTIVATED


public class ZoneDetection : MonoBehaviour
{
    // Drag in the editor the text or image UI you want to appear.
    public Canvas interactionUI;
    private readonly string TagToDetect = "Player";
    public MappeableInput input;
    [SerializeField] private string SceneName = "";
    [SerializeField] private int history = 1;
    [SerializeField] private SkillEnum skillNameForUnlock = SkillEnum.None;

    private bool isPlayerDetected = false;

    private void Awake()
    {
        interactionUI.gameObject.SetActive(false);
        input = new MappeableInput();
        input.InGame.Interact.Enable();
        input.InGame.Interact.started += EnterMinigame;
    }

    private void OnEnable()
    {
        input.InGame.Interact.started += EnterMinigame;
    }

    private void OnDisable()
    {
        input.InGame.Interact.started -= EnterMinigame;
    }



   
    private void OnTriggerEnter2D(Collider2D entity) 
    {
        if(entity.CompareTag(TagToDetect) ) 
        {
        //SHOW UI    
        interactionUI.gameObject.SetActive(true);
        isPlayerDetected = true;
        }
    }


    private void OnTriggerExit2D(Collider2D entity) 
    {
        if(entity.CompareTag(TagToDetect) ) 
        {
            //HIDE UI
            interactionUI.gameObject.SetActive(false);
            isPlayerDetected = false;
        }
    }

    private void EnterMinigame(InputAction.CallbackContext inputContext)
    {
        Debug.Log("Enter Minigame");
        if(!isPlayerDetected) return;
        MinigameSetupData.skillName = skillNameForUnlock;
        MinigameSetupData.history = history;
        SceneLoader.LoadSceneAsyncWithLoadingBar(SceneName, true);
    }



    
}

