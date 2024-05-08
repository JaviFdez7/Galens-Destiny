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
    public string skillName;

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

    public void FinishMinigame()
    {
        UnlockSkill(skillName);
        minigame.SetActive(false);
        endPanel.SetActive(true);
    }

    void UnlockSkill(string skillName)
    {
        foreach (var skill in SkillData.instance.allSkillObjects)
            if (skill.name == skillName)
            {
                skill.UnlockSkill();
                Debug.Log("Skill " + skillName + " unlocked!");
                break;
            }
        else
        {
            Debug.LogError("SkillsMenu instance is not available.");
        }
    }
}