using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerStatsMenu;
    public GameObject playerSkillsMenu;
    public GameObject activeSkillMenu;
    public GameObject warningMenu;
    public GameObject upgradeTreeMenu;
    public UpgradeTree upgradeTree;
    public SkillsMenu skillsMenu;
    public HUD HUD;


    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        playerStatsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        playerSkillsMenu.SetActive(false);
        activeSkillMenu.SetActive(false);
        warningMenu.SetActive(false);
        upgradeTreeMenu.SetActive(false);
    }

    // Update is called once per frame
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
        playerStatsMenu.SetActive(false);
        playerSkillsMenu.SetActive(false);
        activeSkillMenu.SetActive(false);
        warningMenu.SetActive(false);
        upgradeTreeMenu.SetActive(false);
        HUD.ActiveHUD();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnPreviousMenu()
    {
        if(playerStatsMenu.activeSelf) // Player stats menu
        {
            playerStatsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(playerSkillsMenu.activeSelf && !activeSkillMenu.activeSelf) // Player skill menu
        {
            playerSkillsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(activeSkillMenu.activeSelf && !warningMenu.activeSelf) // Player skill menu
        {
            activeSkillMenu.SetActive(false);
        } else if(warningMenu.activeSelf) // Warning menu
        {
            warningMenu.SetActive(false);
            upgradeTree.warningText2.gameObject.SetActive(false);
            skillsMenu.warningText.gameObject.SetActive(false);
        } else if(upgradeTreeMenu.activeSelf) // Player upgrades menu
        {
            upgradeTreeMenu.SetActive(false);
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
        pauseMenu.SetActive(false);
        playerStatsMenu.SetActive(true);
    }

    public void OpenPlayerSkillsMenu()
    {
        pauseMenu.SetActive(false);
        playerStatsMenu.SetActive(false);
        playerSkillsMenu.SetActive(true);
    }

    public int selectedSlot;    
    public void OpenActiveSkillMenu(int slotId)
    {
        selectedSlot = slotId;
        activeSkillMenu.SetActive(true);
    }

    public void OpenWarningMenu()
    {
        warningMenu.SetActive(true);
    }

    public void OpenUpgradeTreeMenu()
    {
        pauseMenu.SetActive(false);
        upgradeTreeMenu.SetActive(true);
    }

}
