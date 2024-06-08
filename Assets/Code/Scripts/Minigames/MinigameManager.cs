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

    public void ReturnToMainGame()
    {
        SceneLoader.LoadSceneOnClick("Main Game");
    }
    public void FinishMinigame()
    {
        if(MinigameSetupData.instance.skillName != SkillEnum.None)
            UnlockSkill(MinigameSetupData.instance.skillName);
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