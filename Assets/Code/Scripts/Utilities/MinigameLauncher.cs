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
    private MappeableInput input = null;
    [SerializeField] private string SceneName = "";
    [SerializeField] private int history = 1;
    [SerializeField] private SkillEnum skillNameForUnlock = SkillEnum.None;

    private void Awake()
    {
        input = new MappeableInput();
        interactionUI.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        input.InGame.Interact.Enable();
        //Subscribe
        input.InGame.Interact.started += EnterMinigame;
    }

    private void OnDisable()
    {
        input.Disable();
        //Unsubscribe
        input.InGame.Interact.started -= EnterMinigame;

    }


   
    private void OnTriggerEnter2D(Collider2D entity) 
    {
        if(entity.CompareTag(TagToDetect) ) 
        {
        //SHOW UI    
        interactionUI.gameObject.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D entity) 
    {
        if(entity.CompareTag(TagToDetect) ) 
        {
            //HIDE UI
            interactionUI.gameObject.SetActive(false);
        }
    }

    private void EnterMinigame(InputAction.CallbackContext inputContext)
    {
        MinigameSetupData.instance.skillName = skillNameForUnlock;
        MinigameSetupData.instance.history = history;
        SceneManager.LoadScene(SceneName);
    }



    
}

