using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider sliderHUD;
    public Slider sliderStatsMenu;

    public static EnergyBar instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public void ChangeMaxEnergy(int maxEnergy)
    {
        sliderHUD.maxValue = maxEnergy;
        sliderStatsMenu.maxValue = maxEnergy;
    }

    public void ChangeCurrentEnergy(int currentEnergy)
    {
        sliderHUD.value = currentEnergy;
        sliderStatsMenu.value = currentEnergy;
    }

    public void InitializeEnergyBar(int maxEnergy, int currentEnergy)
    {
        ChangeCurrentEnergy(currentEnergy);
        ChangeMaxEnergy(maxEnergy);
    }
}
