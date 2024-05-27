using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mapMenu;
    public GameObject playerStatsMenu;
    public GameObject playerSkillsMenu;
    public GameObject equippedSkillsDetailsMenu;
    public GameObject warningMenu;
    public GameObject upgradeTreeMenu;
    public GameObject notebookMenu;

    public static PauseMenu instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }


    public bool isPaused;

    void Start()
    {
        CloseAllViews();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                FastResume();
            } else
            {
                PauseGame();
            }
        }
    }

    public void FastResume() 
    {
        //Add all pause menus GameObject here
        pauseMenu.SetActive(false);
        mapMenu.SetActive(false);
        playerStatsMenu.SetActive(false);
        playerSkillsMenu.SetActive(false);
        equippedSkillsDetailsMenu.SetActive(false);
        warningMenu.SetActive(false);
        upgradeTreeMenu.SetActive(false);
        notebookMenu.SetActive(false);
        HUD.instance.ActiveHUD();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void CloseAllViews() 
    {
        pauseMenu.SetActive(false);
        mapMenu.SetActive(false);
        playerStatsMenu.SetActive(false);
        equippedSkillsDetailsMenu.SetActive(false);
        playerSkillsMenu.SetActive(false);
        warningMenu.SetActive(false);
        upgradeTreeMenu.SetActive(false);
        notebookMenu.SetActive(false);
    }

    public void ReturnPreviousMenu()
    {
        if(playerStatsMenu.activeSelf && !equippedSkillsDetailsMenu.activeSelf) // Player stats menu
        {
            playerStatsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(playerSkillsMenu.activeSelf && !equippedSkillsDetailsMenu.activeSelf && !warningMenu.activeSelf) // Player skill menu
        {
            playerSkillsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(equippedSkillsDetailsMenu.activeSelf) // Equipped skills details menu
        { 
            equippedSkillsDetailsMenu.SetActive(false);
        } else if(warningMenu.activeSelf) // Warning menu
        {
            warningMenu.SetActive(false);
            UpgradeTree.instance.warningText2.gameObject.SetActive(false);
            SkillsMenu.instance.warningText.gameObject.SetActive(false);
        } else if(upgradeTreeMenu.activeSelf && !warningMenu.activeSelf) // Player upgrades menu
        {
            upgradeTreeMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(mapMenu.activeSelf) // Map menu
        { 
            mapMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(notebookMenu.activeSelf) // Notebook menu
        {
            notebookMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }

    public void PauseGame()
    {
        HUD.instance.DisableHUD();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeGame()
    {
        HUD.instance.ActiveHUD();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenPlayerStatsMenu()
    {
        CloseAllViews();
        playerStatsMenu.SetActive(true);
    }

    public void OpenPlayerSkillsMenu()
    {
        CloseAllViews();
        playerSkillsMenu.SetActive(true);
    }

    public void OpenEquippedSkillsDetailsMenu()
    {
        equippedSkillsDetailsMenu.SetActive(true);
    }

    public void OpenWarningMenu()
    {
        warningMenu.SetActive(true);
    }

    public void OpenUpgradeTreeMenu()
    {
        CloseAllViews();
        upgradeTreeMenu.SetActive(true);
    }

    public void OpenMapMenu()
    {
        CloseAllViews();
        mapMenu.SetActive(true);
    }

    public void OpenNotebookMenu()
    {
        CloseAllViews();
        notebookMenu.SetActive(true);
    }

}
