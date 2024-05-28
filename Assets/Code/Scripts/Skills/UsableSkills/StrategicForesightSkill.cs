using UnityEngine;

public class StrategicForesightSkill : ISkill
{
    public void Activate()
    {
        Energy.instance.SpendEnergy(20);
        Debug.Log("USANDO HABILIDAD StrategicForesight");
    }
}
