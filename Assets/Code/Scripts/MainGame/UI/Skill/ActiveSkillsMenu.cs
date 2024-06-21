using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillsMenu;

public class ActiveSkillsMenu : MonoBehaviour
{
    public int index;
    public Image skillImage;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillShortDescription;
    public TextMeshProUGUI skillLongDescription;
    public TextMeshProUGUI skillSlots;
    public List<GameObject> activeSkillOptions;

    public Sprite unequippedSkillSprite;
    public void LoadActiveSkillsSprites(Skill skill)
    {
        if(skill!=null)
        {
            skillImage.sprite = skill.skillImage;
            
            if(skillName != null) skillName.text = skill.name;
            if(skillShortDescription!=null){
                skillShortDescription.text = skill.shortDescription;
            }
            if(skillLongDescription!=null){
                skillLongDescription.text = skill.longDescription;
            }
            if(skillSlots!=null){
                skillSlots.text = skill.skillSlots.ToString();
            }
            for(int i = 0; i < activeSkillOptions.Count; i++){
                activeSkillOptions[i].SetActive(true);
            }
        } else
        {
            if(skillImage!=null) skillImage.sprite = unequippedSkillSprite;
            if(skillName != null) skillName.text = "Unequipped Skill";
            if(skillShortDescription!=null){
                skillShortDescription.text = "Equip a skill available from the Skills menu";
            }
            if(skillLongDescription!=null){
                skillLongDescription.text = "Equip a skill available from the Skills menu";
            }
            if(skillSlots!=null){
                skillSlots.text = "";
            }
            for(int i = 0; i < activeSkillOptions.Count; i++){
                activeSkillOptions[i].SetActive(false);
            }
        }
    }
}
