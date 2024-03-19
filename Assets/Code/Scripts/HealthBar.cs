using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderHUD;
    public Slider sliderStatsMenu;

    public void ChangeMaxHealth(int maxHealth)
    {
        sliderHUD.maxValue = maxHealth;
        sliderStatsMenu.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(int currentHealth)
    {
        sliderHUD.value = currentHealth;
        sliderStatsMenu.value = currentHealth;
    }

    public void InitializeHealthBar(int maxHealth)
    {
        ChangeCurrentHealth(maxHealth);
        ChangeMaxHealth(maxHealth);
    }
}