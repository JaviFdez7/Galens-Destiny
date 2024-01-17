using UnityEngine;

public class EmotionalInsightSkill : ISkill
{
    public void Activate(Energy energy)
    {
        energy.SpendEnergy(2);
        Debug.Log("USANDO HABILIDAD EmotionalInsight");
    }
}
