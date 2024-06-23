using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberSkill : MonoBehaviour, IExecuteCommand
{
    public GameObject bombPrefab;

    public void Execute()
    {
        Energy.instance.SpendEnergy(25);
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
