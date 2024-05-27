using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WarningScreenController : MonoBehaviour
{
    public static WarningScreenController instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public string TryToEquipAnUnequipableSkill(int errorControlCode) // else in ActiveSkill
    {
        string warningMessage = "";
        if(errorControlCode == 0) // if(selectedSkill.skillSlots <= activeSkillSlots + playerStats.skillSlots) 
        {
            warningMessage = "Skill unavailable: insufficient skill slots";
        } else if(errorControlCode == 1) // if(selectedSkill.unlocked)
        {
            warningMessage = "Skill unavailable: locked skill";
        }
        PauseMenu.instance.OpenWarningMenu();
        SkillsMenu.instance.warningText.gameObject.SetActive(true);
        return warningMessage;
    }

    
    public string TryToUnlockAnNonUnlockableUpgrade(int errorControlCode) // else in UnlockUpgrade
    {
        string warningMessage = "";
        if(errorControlCode == 0) // if(playerStats.token >= upgradeLeaf.cost) 
        {
            warningMessage = "Upgrade non-unlockable: insufficient tokens";
        } else if(errorControlCode == 1) // if(upgradeLeaf.available)
        {
            warningMessage = "Upgrade non-unlockable: unavailable upgrade";
        } else if(errorControlCode == 2) // if(!upgradeLeaf.unlocked)
        {
            warningMessage = "Upgrade non-unlockable: upgrade already unlocked";
        }
        PauseMenu.instance.OpenWarningMenu();
        UpgradeTree.instance.warningText2.gameObject.SetActive(true);
        return warningMessage;
    }
}
