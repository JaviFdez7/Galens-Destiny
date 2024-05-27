using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SkillsMenu : MonoBehaviour
{
    public SkillGridManager skillGridManager;
    public SkillInvoker skillInvoker;
    public List<ActiveSkillsMenu> activeSkillsMenus;
    public static SkillsMenu instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public class Skill
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string longDescription { get; private set; }
        public string shortDescription { get; private set; }
        public int skillSlots { get; private set; }
        public bool unlocked { get; set; }
        public bool passive { get; private set; }
        public int energyCost { get; private set; }
        public Sprite skillImage { get; private set; }
        public SkillCommand skillCommand { get; private set; }

        public Skill(int id, string name, string longdescription, string shortDescription, int skillSlots, bool unlocked, bool passive, int energyCost, Sprite skillImage, SkillCommand skillCommand)
        {
            this.id = id;
            this.name = name;
            this.longDescription = longdescription;
            this.shortDescription =  shortDescription;
            this.skillSlots = skillSlots;
            this.unlocked = unlocked;
            this.passive = passive;
            this.energyCost = energyCost;
            this.skillImage = skillImage;
            this.skillCommand = skillCommand;
        }

        public void UnlockSkill(){
            this.unlocked = true;
        }
    }

    // Active Skill -----------------------------------------------------------------------------------------
    public void ActiveSkill(int skillId)
    {
        Skill selectedSkill = SkillData.instance.allSkillObjects[skillId];
        
        int activeSkillSlots = 0;
        
        if(!selectedSkill.passive) // If selected skill is not a passive Skill
        { 
            if(SkillData.instance.activeSkills[selectedSlot] != null) // Controls if the active skill is null or not
            {
                activeSkillSlots = SkillData.instance.activeSkills[selectedSlot].skillSlots;
            }

            if(SkillData.instance.activeSkills.Contains(selectedSkill) && SkillData.instance.activeSkills[selectedSlot]!=selectedSkill) // Make the change if the selected skill is already equipped but in another position 
            {
                int changePosition = 0;
                for(int i = 0; i < SkillData.instance.activeSkills.Count; i++)
                {
                    if(SkillData.instance.activeSkills[i]==selectedSkill)
                    {
                        changePosition = i;
                    }
                }
                PlayerData.instance.skillSlots += SkillData.instance.activeSkills[changePosition].skillSlots;
                SkillData.instance.activeSkills[changePosition] =  null;
                UpdateActiveSkillPanel(null, changePosition);
            }

            if(selectedSkill.unlocked) // Check that the selected skill can be equipped for unlocked
            {
                if(selectedSkill.skillSlots <= activeSkillSlots + PlayerData.instance.skillSlots) // Check that the selected skill can be equipped for skill slots
                {
                    PlayerData.instance.skillSlots += activeSkillSlots;
                    SkillData.instance.activeSkills[selectedSlot] = selectedSkill; // Skill change
                    PlayerData.instance.skillSlots -= selectedSkill.skillSlots;
                    UpdateActiveSkillPanel(selectedSkill, selectedSlot);
                    CreateAndUpdateNewCommandsForNewActiveSkills();
                } else 
                {
                    warningMessage = WarningScreenController.instance.TryToEquipAnUnequipableSkill(0); // Insuficient Skill Slots 
                }
            } else
            {
                warningMessage = WarningScreenController.instance.TryToEquipAnUnequipableSkill(1); // Locked Skill
            }
        } else // If selected skill is a passive Skill
        {
            if(SkillData.instance.passiveActiveSkill != null)
            {
                activeSkillSlots = SkillData.instance.passiveActiveSkill.skillSlots;
            }

            if(selectedSkill.unlocked) // Check that the selected skill can be equipped for unlocked
            {
                if(selectedSkill.skillSlots <= activeSkillSlots + PlayerData.instance.skillSlots) // Check that the selected skill can be equipped for skill slots
                {
                    PlayerData.instance.skillSlots += activeSkillSlots;
                    SkillData.instance.passiveActiveSkill = selectedSkill; // Skill change
                    PlayerData.instance.skillSlots -= selectedSkill.skillSlots;
                    UpdateActiveSkillPanel(selectedSkill, 3);
                } else 
                {
                    warningMessage = WarningScreenController.instance.TryToEquipAnUnequipableSkill(0); // Insuficient Skill Slots 
                }
            } else
            {
                warningMessage = WarningScreenController.instance.TryToEquipAnUnequipableSkill(1); // Locked Skill
            }
        }
    }

    public void CreateAndUpdateNewCommandsForNewActiveSkills()
    {
        for(int i = 0; i < SkillData.instance.activeSkills.Count; i++)
        {
            if(SkillData.instance.activeSkills[i] != null)
            {
                if(i == 0)
                    skillInvoker.AddNewCommand(KeyCode.Q, SkillData.instance.activeSkills[i].skillCommand);
                else if(i == 1)
                    skillInvoker.AddNewCommand(KeyCode.E, SkillData.instance.activeSkills[i].skillCommand);
                else if(i == 2)
                    skillInvoker.AddNewCommand(KeyCode.C, SkillData.instance.activeSkills[i].skillCommand);
            } else
            {
                if(i == 0)
                    skillInvoker.DeleteExistingCommandFromKeyCode(KeyCode.Q);
                else if(i == 1)
                    skillInvoker.DeleteExistingCommandFromKeyCode(KeyCode.E);
                else if(i == 2)
                    skillInvoker.DeleteExistingCommandFromKeyCode(KeyCode.C);
            }
        }

    }

    private string warningMessage;


    // Unequip/Unequipable Skill ------------------------------------------------------------------------------
    public void UnequipSkill(int slotId)
    {
        if(slotId != 3) // Unequip normal Skills
        {
            PlayerData.instance.skillSlots += SkillData.instance.activeSkills[slotId].skillSlots;
            SkillData.instance.activeSkills[slotId] =  null;
            CreateAndUpdateNewCommandsForNewActiveSkills();
        } else // Unequip passive Skill
        {
            PlayerData.instance.skillSlots += SkillData.instance.passiveActiveSkill.skillSlots;
            SkillData.instance.passiveActiveSkill = null;
        }
        UpdateActiveSkillPanel(null, slotId);
        UIText();
    }    

    // Dynamic buttons, information and image after equip or unequip skills --------------------------------------------------------------------
    public void UpdateActiveSkillPanel(Skill skill, int slotId)
    {
        for(int i = 0; i < activeSkillsMenus.Count; i++)
        {
            if(activeSkillsMenus[i].index == slotId)
            {
                activeSkillsMenus[i].LoadActiveSkillsSprites(skill);
            }
        }
    }

    public int selectedSlot;    
    public void ChangeActiveSkillSlot(int slotId)
    {
        selectedSlot = slotId;
        if(slotId == 3)
            ChangeSkillsGrid("Passive");
        else if(slotId==-1)
            ChangeSkillsGrid("None Active");
        else if(slotId==-2)
            ChangeSkillsGrid("None Passive");
        else
            ChangeSkillsGrid("Usable");
                
    }

    // Initialize skills grid
    private List<Skill> passiveSkills = new List<Skill>();
    private List<Skill> usableSkills = new List<Skill>();

    private void FilterSkillsLists()
    {
        foreach(Skill skill in SkillData.instance.allSkillObjects)
            if(skill.passive)
                passiveSkills.Add(skill);
            else
                usableSkills.Add(skill);
    }

    private void ChangeSkillsGrid(string selectedSkillType)
    {
        if(selectedSkillType == "None Active")
            skillGridManager.BuildSkillsGrid(usableSkills, "None");
        if(selectedSkillType == "None Passive")
            skillGridManager.BuildSkillsGrid(passiveSkills, "None");
        else if(selectedSkillType == "Usable")
            skillGridManager.BuildSkillsGrid(usableSkills, "Usable");
        else if(selectedSkillType == "Passive")
            skillGridManager.BuildSkillsGrid(passiveSkills, "Passive");
    }

    

    // Start and Update -----------------------------------------------------------------------------
    void Start()
    {
        UIText();
        UpdateActiveSkillPanel(SkillData.instance.activeSkills[0], 0);
        UpdateActiveSkillPanel(SkillData.instance.activeSkills[1], 1);
        UpdateActiveSkillPanel(SkillData.instance.activeSkills[2], 2);
        UpdateActiveSkillPanel(SkillData.instance.passiveActiveSkill, 3);
        FilterSkillsLists();
        ChangeSkillsGrid("None Active");
    }

    void Update()
    {
        UIText();
    }

    // UI Text ---------------------------------------------------------------------------------
    public TextMeshProUGUI warningText;

    public List<TextMeshProUGUI> skillSlotsText;

    public void UIText()
    {
        for(int i = 0; i < skillSlotsText.Count; i++)
        {
            skillSlotsText[i].text = "Skill Slots: " + PlayerData.instance.skillSlots.ToString() + " / " + PlayerData.instance.skillSlotsMax.ToString();
        }
        
        warningText.text = "" + warningMessage;
    }
}