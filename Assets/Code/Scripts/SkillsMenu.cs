using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillsMenu : MonoBehaviour
{
    public PlayerStats playerStats;
    public PauseMenu pauseMenu;
    private List<Skill> activeSkills = new List<Skill> { null, null, null };

    public class Skill
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public int skillSlots { get; private set; }
        public bool unlocked { get; private set; }

        public Skill(int id, string name, string description, int skillSlots, bool unlocked)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.skillSlots = skillSlots;
            this.unlocked = unlocked;
        }
    }

    public List<Skill> allSkillObjects = new List<Skill>();    
    
    public void Initialize()
    {
        allUnequipButtons.Add(unequipButtonQ);
        allUnequipButtons.Add(unequipButtonE);
        allUnequipButtons.Add(unequipButtonC);

        Skill skill0 = new Skill(0, "Skill 0", "Opens the secret door.", 1, true);
        Skill skill1 = new Skill(1, "Skill 1", "Opens the secret door.", 1, true);
        Skill skill2 = new Skill(2, "Skill 2", "Opens the secret door.", 2, true);
        Skill skill3 = new Skill(3, "Skill 3", "Opens the secret door.", 2, true);
        Skill skill4 = new Skill(4, "Skill 4", "Opens the secret door.", 2, false);


        allSkillObjects.Add(skill0);
        allSkillObjects.Add(skill1);
        allSkillObjects.Add(skill2);
        allSkillObjects.Add(skill3);
        allSkillObjects.Add(skill4);
    }

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
        }

        if(selectedSkill.unlocked) // Check that the selected skill can be equipped for unlocked
        {
            if(selectedSkill.skillSlots <= activeSkillSlots + playerStats.skillSlots) // Check that the selected skill can be equipped for skill slots
            {
                playerStats.skillSlots += activeSkillSlots;
                activeSkills[pauseMenu.selectedSlot] = selectedSkill; // Skill change
                playerStats.skillSlots -= selectedSkill.skillSlots;
                SetVisibilityUnequipButtons();
                UIText();
            } else 
            {
                TryToEquipAnUnequipableSkill(0);
                Debug.Log("Habilidad no equipable: Skill Slots insuficientes");
            }
        } else
        {
            TryToEquipAnUnequipableSkill(1);
            Debug.Log("Habilidad no equipable: Habilidad bloqueada");
        }

        // Muestra el nombre del objeto Skill en la posición selectedSlot si no es null
        if (activeSkills[pauseMenu.selectedSlot] != null)
        {
            Debug.Log("Nombre del Skill seleccionado: " + activeSkills[pauseMenu.selectedSlot].name);
        }
        else
        {
            Debug.Log("Nombre del Skill seleccionado: null");
        }

        // Muestra los nombres de los Skills en activeSkills, maneja los elementos nulos
        string skillNames = "";
        for (int i = 0; i < activeSkills.Count; i++)
        {
            if (activeSkills[i] != null)
            {
                skillNames += activeSkills[i].name + ", ";
            }
            else
            {
                skillNames += "null, ";
            }
        }
        Debug.Log("Nombres de los Skills en activeSkills: " + skillNames);
    }

    public void UnequipSkill(int slotId)
    {
        playerStats.skillSlots += activeSkills[slotId].skillSlots;
        activeSkills[slotId] =  null;
        allUnequipButtons[slotId].gameObject.SetActive(false);
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

    private string unequipableSkillText;

    public void TryToEquipAnUnequipableSkill(int errorControlCode) // else in ActiveSkill
    {
        pauseMenu.OpenUnequipableSkillMenu();
        if(errorControlCode == 0) // if(selectedSkill.skillSlots <= activeSkillSlots + playerStats.skillSlots) 
        {
            unequipableSkillText = "Skill unavailable: insufficient skill slots";
        } else if(errorControlCode == 1) // if(selectedSkill.unlocked)
        {
            unequipableSkillText = "Skill unavailable: locked skill";
        }
        UIText();
    }

    public Button acceptButton;

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
    }

    public TextMeshProUGUI activeSkill0Name;
    public TextMeshProUGUI activeSkill1Name;
    public TextMeshProUGUI activeSkill2Name;
    public TextMeshProUGUI skillSlots;
    public TextMeshProUGUI unequipableSkillMenuMessage;
    private List<string> activeSkillsName = new List<string> { "Empty", "Empty", "Empty"};

    public void UIText()
    {
        for(int i = 0; i < activeSkills.Count; i++)
        {
            if(activeSkills[i] != null)
            {
                activeSkillsName[i] = activeSkills[i].name;
            } else
            {
                activeSkillsName[i] = "Empty";
            }
        }

        activeSkill0Name.text = "" + activeSkillsName[0];
        activeSkill1Name.text = "" + activeSkillsName[1];
        activeSkill2Name.text = "" + activeSkillsName[2];
        skillSlots.text = "Skill Slots: " + playerStats.skillSlots.ToString() + " / " + playerStats.skillSlotsMax.ToString();
        unequipableSkillMenuMessage.text = "" + unequipableSkillText;
    }
}