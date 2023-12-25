using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider sliderUI;
    public Slider sliderStatsMenu;

    public void ChangeMaxHealth(float maxHealth)
    {
        sliderUI.maxValue = maxHealth;
        sliderStatsMenu.maxValue = maxHealth;
    }

    public void ChangeCurrentHealth(float currentHealth)
    {
        sliderUI.value = currentHealth;
        sliderStatsMenu.value = currentHealth;
    }

    public void InitializeHealthBar(float maxHealth)
    {
        ChangeCurrentHealth(maxHealth);
        ChangeMaxHealth(maxHealth);
    }
}
