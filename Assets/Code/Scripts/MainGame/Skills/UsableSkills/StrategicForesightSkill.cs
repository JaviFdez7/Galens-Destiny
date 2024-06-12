using UnityEngine;

public class StrategicForesightSkill : IExecuteCommand
{
    public void Activate()
    {
        Energy.instance.SpendEnergy(20);
        Debug.Log("USANDO HABILIDAD StrategicForesight");
    }
}
