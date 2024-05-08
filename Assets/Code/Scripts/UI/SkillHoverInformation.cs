using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillsMenu;

public class SkillHoverInformation : MonoBehaviour
{
    public Image skillImage;
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillLongDescriptionText;
    public TextMeshProUGUI skillSlotsText;
    public TextMeshProUGUI adviceText;
    public PlayerStats playerStats;

    public void ChangeSkillInformation(int skillId)
    {
        Skill skill = SkillData.instance.allSkillObjects[skillId];

        if(skill.unlocked)
        {
            skillImage.sprite = skill.skillImage;
            skillImage.color = new Color(1.0f, 1.0f, 1.0f, 1f);
            skillNameText.text = skill.name;
            skillLongDescriptionText.text = skill.longDescription;
            skillSlotsText.text = skill.skillSlots.ToString();
            if(playerStats.skillSlots<skill.skillSlots)
            {
                adviceText.text = "Insuficient Skill Slots";
            } else
            {
                adviceText.text = "";
            }
            if(SkillData.instance.activeSkills.Contains(skill))
            {
                adviceText.text = "Equipped Skill";
            } 
        } else
        {
            skillImage.sprite = skill.skillImage;
            skillImage.color = new Color(0.0f, 0.0f, 0.0f, 1f);
            skillNameText.text = "??????";
            skillLongDescriptionText.text = "";
            skillSlotsText.text = "?";
            adviceText.text = "Locked Skill";
        }

    }
}
