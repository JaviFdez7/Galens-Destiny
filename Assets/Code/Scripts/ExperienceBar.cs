using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider sliderHUD;
    public Slider sliderStatsMenu;

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
