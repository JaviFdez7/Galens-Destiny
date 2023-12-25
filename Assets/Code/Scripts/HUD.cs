using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public HealthBar healthBar;
    public EnergyBar energyBar;
    public ExperienceBar experienceBar;

    public void ActiveHUD()
    {
        healthBar.sliderHUD.gameObject.SetActive(true);
        energyBar.sliderHUD.gameObject.SetActive(true);
        experienceBar.sliderHUD.gameObject.SetActive(true);
    }

    public void DisableHUD()
    {
        healthBar.sliderHUD.gameObject.SetActive(false);
        energyBar.sliderHUD.gameObject.SetActive(false);
        experienceBar.sliderHUD.gameObject.SetActive(false);
    }
}
