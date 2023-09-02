using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Skills : MonoBehaviour
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
        public bool available { get; private set; }

        public Skill(int id, string name, string description, int skillSlots, bool unlocked, bool available)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.skillSlots = skillSlots;
            this.unlocked = unlocked;
            this.available = available;
        }
    }
    public List<Skill> allSkillObjects = new List<Skill>();    
    public void CreateTree()
    {
        Skill skill1 = new Skill(0, "Skill 1", "Opens the secret door.", 1, true, true);
        Skill skill2 = new Skill(1, "Skill 2", "Opens the secret door.", 1, true, true);
        Skill skill3 = new Skill(2, "Skill 3", "Opens the secret door.", 1, true, true);
        Skill skill4 = new Skill(3, "Skill 4", "Opens the secret door.", 1, true, true);


        allSkillObjects.Add(skill1);
        allSkillObjects.Add(skill2);
        allSkillObjects.Add(skill3);
        allSkillObjects.Add(skill4);

    }

    public void ActiveSkill(int skillId){
        Skill selectedSkill = allSkillObjects[skillId];
        activeSkills[pauseMenu.selectedSlot] = selectedSkill;
        Debug.Log(activeSkills[pauseMenu.selectedSlot].name);
        Debug.Log(activeSkills[0].name + activeSkills[1] + activeSkills[2]);

    }



    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(activeSkills.Count);
        CreateTree();
        Debug.Log(allSkillObjects.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}