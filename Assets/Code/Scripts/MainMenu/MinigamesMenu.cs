using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigamesMenu : MonoBehaviour
{

    public void StartMinigame(string minigameSceneName)
    {
        MinigameSetupData.history = 2;
        MinigameSetupData.skillName = SkillEnum.None;
        SceneLoader.LoadSceneAsyncWithLoadingBar(minigameSceneName, true);
    }


}
