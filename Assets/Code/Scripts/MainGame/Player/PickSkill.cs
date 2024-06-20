using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Pipeline.Tasks;
using UnityEngine;
using static SkillsMenu;

public class PickSkill : MonoBehaviour
{

    public SkillEnum skillEnum;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (skillEnum)
            {
                case SkillEnum.Shoot:
                    GameObject shootSkillTransform = GameObject.Find("ShootSkill");
                    SpriteRenderer sp = shootSkillTransform.GetComponentInChildren<SpriteRenderer>();
                    if (sp != null) sp.enabled = true;
                    IExecuteCommand shootSkill = shootSkillTransform.GetComponent<ShootSkill>();
                    SkillData.instance.commands.Add(KeyCode.Mouse0, shootSkill);
                    break;
                case SkillEnum.Drill:
                    GameObject drillSkillTransform = GameObject.Find("DrillSkill");
                    SpriteRenderer spDrill = drillSkillTransform.GetComponentInChildren<SpriteRenderer>();
                    if (spDrill != null) spDrill.enabled = true;
                    IExecuteCommand drillSkill = drillSkillTransform.GetComponent<DrillSkill>();
                    SkillData.instance.commands.Add(KeyCode.Mouse1, drillSkill);
                    break;
                default:
                    Skill skillToUnlock = SkillUtils.GetOneSkillFromAll(skillEnum);
                    skillToUnlock.UnlockSkill();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
