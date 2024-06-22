using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSkillPassive : MonoBehaviour, IExecuteCommand
{
    public GameObject player;
    public int healAmount = 3;
    public float healInterval = 1f;
    private bool isHealing = false;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    //Heals the player every healInterval seconds


    private void Update()
    {
        bool isThisPassiveSelected = SkillData.instance.passiveActiveSkill?.skillEnum == SkillEnum.Heal;
        if (!isHealing && isThisPassiveSelected)
        {
            StartCoroutine(Heal());
        }
    }

    IEnumerator Heal()
    {
        isHealing = true;
        player.GetComponent<Health>().Heal(healAmount);
        yield return new WaitForSeconds(healInterval);
        isHealing = false;
    }

    public void Execute()
    {
        Debug.Log("Passives can't be executed!");
    }



}
