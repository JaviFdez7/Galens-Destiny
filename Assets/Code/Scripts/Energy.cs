using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static Energy instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    private void Start()
    {
        EnergyBar.instance.InitializeEnergyBar(PlayerData.instance.maxEnergy, PlayerData.instance.currentEnergy);
    }

    private void Update()
    {
        UIText();
    }

    public void SpendEnergy(int usedEnergy)
    {
        PlayerData.instance.currentEnergy -= usedEnergy;
        EnergyBar.instance.ChangeCurrentEnergy(PlayerData.instance.currentEnergy);
    }

    public TextMeshProUGUI currentEnergyBarMaxEnergy;

    public void UIText()
    {
        currentEnergyBarMaxEnergy.text = "" + PlayerData.instance.currentEnergy + " / " + PlayerData.instance.maxEnergy;
    }
}
