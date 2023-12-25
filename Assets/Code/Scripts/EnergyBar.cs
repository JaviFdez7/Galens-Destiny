using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider sliderUI;
    public Slider sliderStatsMenu;

    public void ChangeMaxEnergy(float maxEnergy)
    {
        sliderUI.maxValue = maxEnergy;
        sliderStatsMenu.maxValue = maxEnergy;
    }

    public void ChangeCurrentEnergy(float currentEnergy)
    {
        sliderUI.value = currentEnergy;
        sliderStatsMenu.value = currentEnergy;
    }

    public void InitializeEnergyBar(float maxEnergy)
    {
        ChangeCurrentEnergy(maxEnergy);
        ChangeMaxEnergy(maxEnergy);
    }
}
