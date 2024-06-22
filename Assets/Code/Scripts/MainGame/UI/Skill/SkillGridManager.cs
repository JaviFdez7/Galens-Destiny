using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SkillsMenu;
using TMPro;

public class SkillGridManager : MonoBehaviour
{
    public GameObject skillGridElementPrefab;
    public GridLayoutGroup skillGridPanel;
    public GameObject filterSkillsToggle;
    public SkillHoverInformation skillHoverInformation;
    public TextMeshProUGUI activeSkillsToggleText;
    public TextMeshProUGUI passiveSkillsToggleText;

    public void BuildSkillsGrid(List<Skill> skills, string selectedSkillTypeIsPassive)
    {
        if(skills.Count == 0)
        {
            return;
        }
        if(selectedSkillTypeIsPassive != "None")
            filterSkillsToggle.SetActive(false);
        else
            filterSkillsToggle.SetActive(true);

        if(skills[0].passive)
        {
            activeSkillsToggleText.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            passiveSkillsToggleText.color = new Color(1.0f, 1.0f, 1.0f, 1f);
        }
        else
        {
            passiveSkillsToggleText.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            activeSkillsToggleText.color = new Color(1.0f, 1.0f, 1.0f, 1f);
        }

        foreach (Transform child in skillGridPanel.transform) // When selecting passive or usable skill, you have to delete the current skill to insert the new ones
        {
            Destroy(child.gameObject);
        }


        foreach (Skill skill in skills)
        {
            if(skill.skillEnum != SkillEnum.Shoot || skill.skillEnum != SkillEnum.Drill || skill.skillEnum != SkillEnum.Empty)
            {
                GameObject skillGridElement = Instantiate(skillGridElementPrefab, skillGridPanel.transform);
                skillGridElement.GetComponent<Image>().sprite = skill.skillImage;
                skillGridElement.GetComponent<SkillHoverDetection>().id = skill.id;
                skillGridElement.GetComponent<SkillHoverDetection>().skillHoverInformation = skillHoverInformation;

                if(selectedSkillTypeIsPassive != "None")
                {
                    skillGridElement.GetComponent<Button>().onClick.AddListener(() => SkillsMenu.instance.ActiveSkill(skill.id));

                    ColorBlock colors = skillGridElement.GetComponent<Button>().colors;
                    colors.highlightedColor = new Color(1.0f, 1.0f, 1.0f, 0.3f);
                    skillGridElement.GetComponent<Button>().colors = colors;
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
}
