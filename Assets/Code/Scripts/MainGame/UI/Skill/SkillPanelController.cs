using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelController : MonoBehaviour
{
    public List<GameObject> skillPanels;
    
    public void HighlightedPanel()
    {
        foreach(GameObject skillPanel in skillPanels)
        {
            int index = skillPanel.GetComponent<ActiveSkillsMenu>().index;
            if(index == SkillsMenu.instance.selectedSlot)
            {
                skillPanel.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            } else 
            {
                skillPanel.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.666f);
            }
        }
    }
}
