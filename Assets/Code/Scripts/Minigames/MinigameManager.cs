using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SkillsMenu;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    public GameObject minigame;
    public GameObject beginPanel;
    public GameObject endPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        minigame.SetActive(false);
        endPanel.SetActive(false);
    }

    public void StartMinigame()
    {
        minigame.SetActive(true);
        beginPanel.SetActive(false);
    }
    /// <summary>
    /// This method is called when the player wants to exit the minigame
    /// In will go to the MainMenu or MainGame scene depending on the last scene loaded
    /// </summary>
    public void ExitMiniGame()
    {
        //Dont save the current scene name, its referenced in the interactables of MainMenu and MainGame
        SceneLoader.LoadSceneAsyncWithLoadingBar(SceneLoader.lastSceneName, false);
    }
    public void FinishMinigame()
    {
        if(MinigameSetupData.skillName != SkillEnum.None)
            UnlockSkill(MinigameSetupData.skillName);
        minigame.SetActive(false);
        endPanel.SetActive(true);
    }

    void UnlockSkill(SkillEnum skillName)
    {
        foreach (Skill skill in SkillData.instance.allSkillObjects)
            if (skill.skillEnum == skillName)
            {
                skill.UnlockSkill();
                break;
            }
    }
}