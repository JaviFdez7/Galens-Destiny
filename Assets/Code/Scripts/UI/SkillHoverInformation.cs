using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SkillsMenu;

public class SkillHoverInformation : MonoBehaviour
{
    public SkillsMenu skillsMenu;
    public Image skillImage;
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillLongDescriptionText;
    public TextMeshProUGUI skillSlotsText;

    public void ChangeSkillInformation(int skillId)
    {
        skillImage.sprite = skillsMenu.allSkillObjects[skillId].skillImage;
        skillNameText.text = skillsMenu.allSkillObjects[skillId].name;
        skillLongDescriptionText.text = skillsMenu.allSkillObjects[skillId].longDescription;
        skillSlotsText.text = skillsMenu.allSkillObjects[skillId].skillSlots.ToString();
    }
}
