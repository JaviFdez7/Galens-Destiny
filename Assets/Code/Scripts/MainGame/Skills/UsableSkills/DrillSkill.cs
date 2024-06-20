using UnityEngine;

public class DrillSkill : MonoBehaviour, IExecuteCommand
{
    public void Execute()
    {
        Energy.instance.SpendEnergy(20);
        Debug.Log("USANDO HABILIDAD StrategicForesight");
    }
}
