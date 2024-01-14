using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SkillsMenu;

public class SkillGridManager : MonoBehaviour
{
    public GameObject skillGridElementPrefab;
    public GridLayoutGroup skillGridPanel;
    public SkillHoverInformation skillHoverInformation;
    public SkillsMenu skillsMenu;

    public void BuildSkillsGrid(List<Skill> skills, string selectedSkillTypeIsPassive)
    {
            
        foreach (Transform child in skillGridPanel.transform) // When selecting passive or usable skill, you have to delete the current skill to insert the new ones
        {
            Destroy(child.gameObject);
        }


        foreach (Skill skill in skills)
        {
            GameObject skillGridElement = Instantiate(skillGridElementPrefab, skillGridPanel.transform);
            skillGridElement.GetComponent<Image>().sprite = skill.skillImage;
            skillGridElement.GetComponent<SkillHoverDetection>().id = skill.id;
            skillGridElement.GetComponent<SkillHoverDetection>().skillHoverInformation = skillHoverInformation;

            if(selectedSkillTypeIsPassive != "None")
            {
                skillGridElement.GetComponent<Button>().onClick.AddListener(() => skillsMenu.ActiveSkill(skill.id));
            }

            if (!skill.unlocked) // Change locked skills to black
            {
                Image skillImage = skillGridElement.GetComponent<Image>();
                skillImage.color = new Color(0.0f, 0.0f, 0.0f, 1f);
            }

            if(selectedSkillTypeIsPassive == "None") // Change the opaticity if you don't want to change any skill
            {
                Color color = skillGridElement.GetComponent<Image>().color;
                color.a = 0.6f;
                skillGridElement.GetComponent<Image>().color = color;
            } else if(selectedSkillTypeIsPassive == "Passive" || selectedSkillTypeIsPassive == "Usable")
            {
                Color color = skillGridElement.GetComponent<Image>().color;
                color.a = 1f;
                skillGridElement.GetComponent<Image>().color = color;
            }
        }
    }


}
