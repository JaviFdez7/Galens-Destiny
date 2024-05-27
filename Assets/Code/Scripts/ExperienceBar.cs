using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider sliderHUD;
    public Slider sliderStatsMenu;

    public static ExperienceBar instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public void ChangeMaxExperience(int maxExperience)
    {
        sliderHUD.maxValue = maxExperience;
        sliderStatsMenu.maxValue = maxExperience;
    }

    public void ChangeCurrentExperience(int currentExperience)
    {
        sliderHUD.value = currentExperience;
        sliderStatsMenu.value = currentExperience;
    }

    public void InitializeExperienceBar(int maxExperience, int maxExp)
    {
        ChangeCurrentExperience(maxExperience);
        ChangeMaxExperience(maxExp);
    }
}
