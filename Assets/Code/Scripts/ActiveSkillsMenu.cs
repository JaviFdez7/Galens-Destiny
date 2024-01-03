using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillsMenu;

public class ActiveSkillsMenu : MonoBehaviour
{
    public int index;
    public SkillsMenu skillsMenu;
    public Image skillImage;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillShortDescription;
    public Sprite unequippedSkillSprite;
    public void LoadActiveSkillsSprites(Skill skill)
    {
        if(skill!=null)
        {
            skillImage.sprite = skill.skillImage;
            skillName.text = skill.name;
            skillShortDescription.text = skill.shortDescription;
        } else
        {
            skillImage.sprite = unequippedSkillSprite;
            skillName.text = "UNEQUIPPED SKILL";
            skillShortDescription.text = "Equip a skill available from the Skills menu";
        }
    }
}
