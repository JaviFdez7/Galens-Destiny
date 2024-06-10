using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public EnergyBar energyBar;
    public ExperienceBar experienceBar;

    public static HUD instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void ActiveHUD()
    {
        HealthBar.instance.sliderHUD.gameObject.SetActive(true);
        energyBar.sliderHUD.gameObject.SetActive(true);
        experienceBar.sliderHUD.gameObject.SetActive(true);
    }

    public void DisableHUD()
    {
        HealthBar.instance.sliderHUD.gameObject.SetActive(false);
        energyBar.sliderHUD.gameObject.SetActive(false);
        experienceBar.sliderHUD.gameObject.SetActive(false);
    }
}
