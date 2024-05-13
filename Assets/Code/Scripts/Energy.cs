using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int maxEnergy = 100;
    public int currentEnergy;
    public EnergyBar energyBar;

    private void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.InitializeEnergyBar(currentEnergy);
    }

    private void Update()
    {
        UIText();
    }

    public void SpendEnergy(int usedEnergy)
    {
        currentEnergy -= usedEnergy;
        energyBar.ChangeCurrentEnergy(currentEnergy);
    }

    public TextMeshProUGUI currentEnergyBarMaxEnergy;

    public void UIText()
    {
        currentEnergyBarMaxEnergy.text = "" + currentEnergy + " / " + maxEnergy;
    }
}
