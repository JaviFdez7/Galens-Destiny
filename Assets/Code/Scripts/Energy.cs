using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public float maxEnergy = 100f;
    public float currentEnergy;
    public EnergyBar energyBar;

    private void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.InitializeEnergyBar(currentEnergy);
    }

    public void SpendEnergy(float usedEnergy)
    {
        currentEnergy -= usedEnergy;
        energyBar.ChangeCurrentEnergy(currentEnergy);
    }
}
