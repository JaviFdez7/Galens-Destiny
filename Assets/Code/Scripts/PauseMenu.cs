using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mapMenu;
    public GameObject playerStatsMenu;
    public GameObject playerSkillsMenu;
    public GameObject activeSkillMenu;
    public GameObject equippedSkillsDetailsMenu;
    public GameObject warningMenu;
    public GameObject upgradeTreeMenu;
    public GameObject notebookMenu;
    public UpgradeTree upgradeTree;
    public SkillsMenu skillsMenu;
    public HUD HUD;


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
        activeSkillMenu.SetActive(false);
        equippedSkillsDetailsMenu.SetActive(false);
        warningMenu.SetActive(false);
        upgradeTreeMenu.SetActive(false);
        notebookMenu.SetActive(false);
        HUD.ActiveHUD();
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
        activeSkillMenu.SetActive(false);
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
        } else if(playerSkillsMenu.activeSelf && !activeSkillMenu.activeSelf && !equippedSkillsDetailsMenu.activeSelf) // Player skill menu
        {
            playerSkillsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(activeSkillMenu.activeSelf && !warningMenu.activeSelf && !equippedSkillsDetailsMenu.activeSelf) // Player skill menu
        {
            activeSkillMenu.SetActive(false);
        } else if(equippedSkillsDetailsMenu.activeSelf){ // Equipped skills details menu
            equippedSkillsDetailsMenu.SetActive(false);
        }
         else if(warningMenu.activeSelf) // Warning menu
        {
            warningMenu.SetActive(false);
            upgradeTree.warningText2.gameObject.SetActive(false);
            skillsMenu.warningText.gameObject.SetActive(false);
        } else if(upgradeTreeMenu.activeSelf) // Player upgrades menu
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
        HUD.DisableHUD();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void ResumeGame()
    {
        HUD.ActiveHUD();
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

    public int selectedSlot;    
    public void OpenActiveSkillMenu(int slotId)
    {
        selectedSlot = slotId;
        activeSkillMenu.SetActive(true);
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
