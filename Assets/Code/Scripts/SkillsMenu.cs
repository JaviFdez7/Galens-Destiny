using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SkillsMenu : MonoBehaviour
{
    public PlayerStats playerStats;
    public WarningScreenController warningScreenController;
    public PauseMenu pauseMenu;
    public List<ActiveSkillsMenu> activeSkillsMenus;
    public List<Sprite> skillImages;
    public List<Skill> activeSkills = new List<Skill> { null, null, null };
    
    public class Skill
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string longDescription { get; private set; }
        public string shortDescription { get; private set; }

        public int skillSlots { get; private set; }
        public bool unlocked { get; private set; }
        public Sprite skillImage { get; private set; }

        public Skill(int id, string name, string longdescription, string shortDescription, int skillSlots, bool unlocked, Sprite skillImage)
        {
            this.id = id;
            this.name = name;
            this.longDescription = longdescription;
            this.shortDescription =  shortDescription;
            this.skillSlots = skillSlots;
            this.unlocked = unlocked;
            this.skillImage = skillImage;
        }
    }

    public List<Skill> allSkillObjects = new List<Skill>();    
    
    public void Initialize()
    {
        allUnequipButtons.Add(unequipButtonQ);
        allUnequipButtons.Add(unequipButtonE);
        allUnequipButtons.Add(unequipButtonC);

        Skill skill0 = new Skill(0, "Skill 0", "This is the skill 0 with a very very very very very very very long description", "Kill all enemies around the IA's mate", 1, true, skillImages[0]);
        Skill skill1 = new Skill(1, "Skill 1", "This is the skill 1 with a very very very very very very very long description", "Generates a large storm that pushes enemies", 1, true, skillImages[1]);
        Skill skill2 = new Skill(2, "Skill 2", "This is the skill 2 with a very very very very very very very long description", "Teleport in a range's distance", 2, true, skillImages[2]);
        Skill skill3 = new Skill(3, "Skill 3", "This is the skill 3 with a very very very very very very very long description", "Summon  3 littles robots", 2, true, skillImages[3]);
        Skill skill4 = new Skill(4, "Skill 4", "This is the skill 4 with a very very very very very very very long description", "Throw a big energy ball", 2, false, skillImages[4]);


        allSkillObjects.Add(skill0);
        allSkillObjects.Add(skill1);
        allSkillObjects.Add(skill2);
        allSkillObjects.Add(skill3);
        allSkillObjects.Add(skill4);
    }

    // Active Skill -----------------------------------------------------------------------------------------
    public void ActiveSkill(int skillId){
        Skill selectedSkill = allSkillObjects[skillId];

        int activeSkillSlots = 0;
        if(activeSkills[pauseMenu.selectedSlot] != null) // Controls if the active skill is null or not
        {
            activeSkillSlots = activeSkills[pauseMenu.selectedSlot].skillSlots;
        }

        if(activeSkills.Contains(selectedSkill) && activeSkills[pauseMenu.selectedSlot]!=selectedSkill) // Make the change if the selected skill is already equipped but in another position 
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
                activeSkills[pauseMenu.selectedSlot] = selectedSkill; // Skill change
                playerStats.skillSlots -= selectedSkill.skillSlots;
                SetVisibilityUnequipButtons();
                UpdateActiveSkillPanel(selectedSkill, pauseMenu.selectedSlot);
            } else 
            {
                warningMessage = warningScreenController.TryToEquipAnUnequipableSkill(0); // Insuficient Skill Slots 
            }
        } else
        {
            warningMessage = warningScreenController.TryToEquipAnUnequipableSkill(1); // Locked Skill
        }
    }

    private string warningMessage;


    // Unequip/Unequipable Skill ------------------------------------------------------------------------------
    public void UnequipSkill(int slotId)
    {
        playerStats.skillSlots += activeSkills[slotId].skillSlots;
        activeSkills[slotId] =  null;
        allUnequipButtons[slotId].gameObject.SetActive(false);
        UpdateActiveSkillPanel(null, slotId);
        UIText();
    }    

    public Button unequipButtonQ;
    public Button unequipButtonE;
    public Button unequipButtonC;
    private List<Button> allUnequipButtons = new List<Button>();

    public void SetVisibilityUnequipButtons()
    {
        for(int i = 0; i < allUnequipButtons.Count; i++)
        {
            if(activeSkills[i]!=null)
            {
                allUnequipButtons[i].gameObject.SetActive(true);
            } else {
                allUnequipButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public Button acceptButton;



    // Dynamic buttons and image after equip or unequip skills --------------------------------------------------------------------
    public void UpdateButtonsAndImagesAfterEquipOrUnequipSkills()
    {

    }

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
    
    // Start and Update -----------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        SetVisibilityUnequipButtons();
        UIText();
    }

    // Update is called once per frame
    void Update()
    {
        UIText();
    }

    // UI Text ---------------------------------------------------------------------------------
    public TextMeshProUGUI warningText;
    public TextMeshProUGUI activeSkill0Name;
    public TextMeshProUGUI activeSkill0Cost;
    public TextMeshProUGUI activeSkill1Name;
    public TextMeshProUGUI activeSkill1Cost;

    public TextMeshProUGUI activeSkill2Name;
    public TextMeshProUGUI activeSkill2Cost;

    public TextMeshProUGUI skill0Cost;
    public TextMeshProUGUI skill1Cost;
    public TextMeshProUGUI skill2Cost;
    public TextMeshProUGUI skill3Cost;
    public TextMeshProUGUI skill4Cost;


    public TextMeshProUGUI skillSlots;
    private List<string> activeSkillsName = new List<string> { "Empty", "Empty", "Empty"};
    private List<string> activeSkillsCost = new List<string> { "0", "0", "0"};


    public void UIText()
    {
        for(int i = 0; i < activeSkills.Count; i++)
        {
            if(activeSkills[i] != null)
            {
                activeSkillsName[i] = activeSkills[i].name;
                activeSkillsCost[i] = activeSkills[i].skillSlots.ToString();
                
            } else
            {
                activeSkillsName[i] = "Empty";
                activeSkillsCost[i] = "0";
            }
        }

        activeSkill0Name.text = "" + activeSkillsName[0];
        activeSkill0Cost.text = "" + activeSkillsCost[0];

        activeSkill1Name.text = "" + activeSkillsName[1];
        activeSkill1Cost.text = "" + activeSkillsCost[1];

        activeSkill2Name.text = "" + activeSkillsName[2];
        activeSkill2Cost.text = "" + activeSkillsCost[2];

        skill0Cost.text = "" + allSkillObjects[0].skillSlots.ToString();
        skill1Cost.text = "" + allSkillObjects[1].skillSlots.ToString();
        skill2Cost.text = "" + allSkillObjects[2].skillSlots.ToString();
        skill3Cost.text = "" + allSkillObjects[3].skillSlots.ToString();
        skill4Cost.text = "" + allSkillObjects[4].skillSlots.ToString();

        skillSlots.text = "Skill Slots: " + playerStats.skillSlots.ToString() + " / " + playerStats.skillSlotsMax.ToString();
        warningText.text = "" + warningMessage;
    }
}