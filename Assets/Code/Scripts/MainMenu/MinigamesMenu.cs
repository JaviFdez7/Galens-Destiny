using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigamesMenu : MonoBehaviour
{

    public int history=1;

    public void SetHistory(int history)
    {
        this.history = history;
    }
    public void StartMinigame(string minigameSceneName)
    {
        MinigameSetupData.history = history;
        MinigameSetupData.skillName = SkillEnum.None;
        SceneLoader.LoadSceneAsyncWithLoadingBar(minigameSceneName, true);
    }


}
