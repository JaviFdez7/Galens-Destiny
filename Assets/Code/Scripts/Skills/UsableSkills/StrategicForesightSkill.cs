using UnityEngine;

public class StrategicForesightSkill : ISkill
{
    public void Activate(Energy energy)
    {
        energy.SpendEnergy(20);
        Debug.Log("USANDO HABILIDAD StrategicForesight");
    }
}
