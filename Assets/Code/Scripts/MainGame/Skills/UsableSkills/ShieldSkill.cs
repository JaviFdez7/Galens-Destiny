
using System;
using System.Collections;
using UnityEngine;

public class ShieldSkill : MonoBehaviour, IExecuteCommand
{
    public int energyCost = 10;
    public float shieldDuration = 8;
    public GameObject shieldPrefab;

    private GameObject shield;
    public void Execute()
    {
        if(PlayerData.instance.currentEnergy < energyCost) return;
        if(shield != null) return;
        SoundMainManager.instance.PlayShield();
        Energy.instance.SpendEnergy(10);
        shield = Instantiate(shieldPrefab, transform.position, Quaternion.identity);
        //THIS IS REALLY IMPORTANT. The game object where skills scritps are attached to is allways in the player coordinates.
        shield.transform.SetParent(transform);
        StartCoroutine(ShieldDuration());
    }

    private IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(shieldDuration);
        if(shield !=null) Destroy(shield);
    }
}