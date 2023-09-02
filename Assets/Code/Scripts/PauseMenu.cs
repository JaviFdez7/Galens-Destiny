using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playerStatsMenu;
    public GameObject playerSkillsMenu;

    public GameObject activeSkillMenu;


    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        playerStatsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        playerSkillsMenu.SetActive(false);
        activeSkillMenu.SetActive(false);
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
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnPreviousMenu()
    {
        if(playerStatsMenu.activeSelf)
        {
            playerStatsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(playerSkillsMenu.activeSelf)
        {
            playerSkillsMenu.SetActive(false);
            pauseMenu.SetActive(true);
        } else if(activeSkillMenu.activeSelf){
            activeSkillMenu.SetActive(false);
            playerSkillsMenu.SetActive(true);
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
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
        playerSkillsMenu.SetActive(true);
    }

    public int selectedSlot;    
    public void OpenActiveSkillMenu(int slotId)
    {
        selectedSlot = slotId;
        playerSkillsMenu.SetActive(false);
        activeSkillMenu.SetActive(true);
    }
}
