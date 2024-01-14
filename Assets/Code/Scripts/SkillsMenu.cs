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
    public PlayerStats playerStats;
    public WarningScreenController warningScreenController;
    public SkillGridManager skillGridManager;
    public List<ActiveSkillsMenu> activeSkillsMenus;
    public List<Sprite> skillImages;
    public List<Skill> activeSkills = new List<Skill> { null, null, null };
    private Skill passiveActiveSkill = null;
    
    public class Skill
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string longDescription { get; private set; }
        public string shortDescription { get; private set; }

        public int skillSlots { get; private set; }
        public bool unlocked { get; private set; }
        public bool passive { get; private set; }
        public Sprite skillImage { get; private set; }

        public Skill(int id, string name, string longdescription, string shortDescription, int skillSlots, bool unlocked, bool passive, Sprite skillImage)
        {
            this.id = id;
            this.name = name;
            this.longDescription = longdescription;
            this.shortDescription =  shortDescription;
            this.skillSlots = skillSlots;
            this.unlocked = unlocked;
            this.passive = passive;
            this.skillImage = skillImage;
        }
    }

    public List<Skill> allSkillObjects = new List<Skill>();    
    
    public void Initialize()
    {
        Skill skill0 = new Skill(0, "Emotional Insight", "Recognizing and managing one's own and others' emotions, fostering healthy relationships and making conscientious decisions.", "Kill all enemies around the IA's mate", 1, true, false, skillImages[0]);
        Skill skill1 = new Skill(1, "Strategic Foresight", "Anticipating trends, assessing risks, and designing long-term strategies for personal or business success.", "Generates a large storm that pushes enemies", 1, true, false, skillImages[1]);
        Skill skill2 = new Skill(2, "Multidimensional Creativity", "Approaching problems from diverse perspectives, merging ideas to generate innovative solutions.", "Teleport in a range's distance", 2, true, false, skillImages[2]);
        Skill skill3 = new Skill(3, "Resilient Adaptability", "Adapting flexibly to changes, overcoming challenges with emotional and mental resilience.", "Summon  3 littles robots", 2, true, false, skillImages[3]);
        Skill skill4 = new Skill(4, "Persuasive Communication", "Ethically influencing through compelling arguments, using empathy and integrity to achieve consensus and positive impact.", "Throw a big energy ball", 2, false, false, skillImages[4]);
        Skill skill5Passive = new Skill(5, "Fire Punch", "The skill to control and manipulate flames with precision, used for both defensive and offensive purposes. Requires mental focus and a deep understanding of fire dynamics.", "Expert fire control for offense and defense.", 2, true, true, skillImages[5]);
        Skill skill6 = new Skill(6, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, false, skillImages[6]);
        Skill skill7 = new Skill(7, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, false, skillImages[7]);
        Skill skill8Passive = new Skill(8, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, skillImages[8]);
        Skill skill9Passive = new Skill(9, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, skillImages[9]);
        Skill skill10Passive = new Skill(10, "Locked Skill", "Locked Skill", "Locked Skill", 1, true, true, skillImages[10]);
        Skill skill11Passive = new Skill(11, "Locked Skill", "Locked Skill", "Locked Skill", 1, true, true, skillImages[11]);
        Skill skill12Passive = new Skill(12, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, skillImages[12]);

        allSkillObjects.Add(skill0);
        allSkillObjects.Add(skill1);
        allSkillObjects.Add(skill2);
        allSkillObjects.Add(skill3);
        allSkillObjects.Add(skill4);
        allSkillObjects.Add(skill5Passive);
        allSkillObjects.Add(skill6);
        allSkillObjects.Add(skill7);
        allSkillObjects.Add(skill8Passive);
        allSkillObjects.Add(skill9Passive);
        allSkillObjects.Add(skill10Passive);
        allSkillObjects.Add(skill11Passive);
        allSkillObjects.Add(skill12Passive);
    }

    // Active Skill -----------------------------------------------------------------------------------------
    public void ActiveSkill(int skillId)
    {
        Skill selectedSkill = allSkillObjects[skillId];
        
        int activeSkillSlots = 0;
        
        if(!selectedSkill.passive) // If selected skill is not a passive Skill
        { 
            if(activeSkills[selectedSlot] != null) // Controls if the active skill is null or not
            {
                activeSkillSlots = activeSkills[selectedSlot].skillSlots;
            }

            if(activeSkills.Contains(selectedSkill) && activeSkills[selectedSlot]!=selectedSkill) // Make the change if the selected skill is already equipped but in another position 
            {
                int changePosition = 0;
                for(int i = 0; i<activeSkills.Count; i++)
                {
                    if(activeSkills[i]==selectedSkill)
                    {
                        changePosition = i;
                    }
                }
                playerStats.skillSlots += activeSkills[changePosition].skillSlots;
                activeSkills[changePosition] =  null;
                UpdateActiveSkillPanel(null, changePosition);
            }

            if(selectedSkill.unlocked) // Check that the selected skill can be equipped for unlocked
            {
                if(selectedSkill.skillSlots <= activeSkillSlots + playerStats.skillSlots) // Check that the selected skill can be equipped for skill slots
                {
                    playerStats.skillSlots += activeSkillSlots;
                    activeSkills[selectedSlot] = selectedSkill; // Skill change
                    playerStats.skillSlots -= selectedSkill.skillSlots;
                    UpdateActiveSkillPanel(selectedSkill, selectedSlot);
                } else 
                {
                    warningMessage = warningScreenController.TryToEquipAnUnequipableSkill(0); // Insuficient Skill Slots 
                }
            } else
            {
                warningMessage = warningScreenController.TryToEquipAnUnequipableSkill(1); // Locked Skill
            }
        } else // If selected skill is a passive Skill
        {
            if(passiveActiveSkill != null)
            {
                activeSkillSlots = passiveActiveSkill.skillSlots;
            }

            if(selectedSkill.unlocked) // Check that the selected skill can be equipped for unlocked
            {
                if(selectedSkill.skillSlots <= activeSkillSlots + playerStats.skillSlots) // Check that the selected skill can be equipped for skill slots
                {
                    playerStats.skillSlots += activeSkillSlots;
                    passiveActiveSkill = selectedSkill; // Skill change
                    playerStats.skillSlots -= selectedSkill.skillSlots;
                    UpdateActiveSkillPanel(selectedSkill, 3);
                } else 
                {
                    warningMessage = warningScreenController.TryToEquipAnUnequipableSkill(0); // Insuficient Skill Slots 
                }
            } else
            {
                warningMessage = warningScreenController.TryToEquipAnUnequipableSkill(1); // Locked Skill
            }
        }
    }

    private string warningMessage;


    // Unequip/Unequipable Skill ------------------------------------------------------------------------------
    public void UnequipSkill(int slotId)
    {
        if(slotId != 3) // Unequip normal Skills
        {
            playerStats.skillSlots += activeSkills[slotId].skillSlots;
            activeSkills[slotId] =  null;
        } else // Unequip passive Skill
        {
            playerStats.skillSlots += passiveActiveSkill.skillSlots;
            passiveActiveSkill = null;
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
        else if(slotId<0)
            ChangeSkillsGrid("None");
        else
            ChangeSkillsGrid("Usable");
                
    }

    // Initialize skills grid
    private List<Skill> passiveSkills = new List<Skill>();
    private List<Skill> usableSkills = new List<Skill>();

    private void FilterSkillsLists()
    {
        foreach(Skill skill in allSkillObjects)
            if(skill.passive)
                passiveSkills.Add(skill);
            else
                usableSkills.Add(skill);
    }

    private void ChangeSkillsGrid(string selectedSkillType)
    {
        if(selectedSkillType == "None")
            ApplyNewSkillsGrid(usableSkills, "None");
        else if(selectedSkillType == "Usable")
            ApplyNewSkillsGrid(usableSkills, "Usable");
        else if(selectedSkillType == "Passive")
            ApplyNewSkillsGrid(passiveSkills, "Passive");
    }

    private void ApplyNewSkillsGrid(List<Skill> skills, string selectedSkillType)
    {
        skillGridManager.BuildSkillsGrid(skills, selectedSkillType);
    }
    
    // Start and Update -----------------------------------------------------------------------------
    void Start()
    {
        Initialize();
        UIText();
        UpdateActiveSkillPanel(activeSkills[0], 0);
        UpdateActiveSkillPanel(activeSkills[1], 1);
        UpdateActiveSkillPanel(activeSkills[2], 2);
        UpdateActiveSkillPanel(passiveActiveSkill, 3);
        FilterSkillsLists();
        ChangeSkillsGrid("None");
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
            skillSlotsText[i].text = "Skill Slots: " + playerStats.skillSlots.ToString() + " / " + playerStats.skillSlotsMax.ToString();
        }
        
        warningText.text = "" + warningMessage;
    }
}