using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberSkill : MonoBehaviour, IExecuteCommand
{
    public GameObject bombPrefab;

    public void Execute()
    {
        if (PlayerData.instance.currentEnergy - 25 < 0)
            return;

        SoundMainManager.instance.PlayBomb();
        Energy.instance.SpendEnergy(25);
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
