using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public PlayerStats playerStats;
    private List<SkillObject> activeSkills;

    private int slotId;    

    public class SkillObject
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public int skillSlots { get; private set; }
        public bool unlocked { get; private set; }
        public bool available { get; private set; }

        public SkillObject(int id, string name, string description, int skillSlots, bool unlocked, bool available)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.skillSlots = skillSlots;
            this.unlocked = unlocked;
            this.available = available;
        }
    }
    public List<SkillObject> allSkillObjects = new List<SkillObject>();    
    public void CreateTree()
    {
        SkillObject skill1 = new SkillObject(1, "Skill 1", "Opens the secret door.", 1, false, true);

        allSkillObjects.Add(skill1);
    }

    public void activeSkill(SkillObject skill, int target)
    {
        if(qSkill != null)
        {
            if(skill.skillSlots <= playerStats.skillSlots + qSkill.skillSlots)
            {
                playerStats.skillSlots -= qSkill.skillSlots;
                qSkill = skill;
                playerStats.skillSlots += skill.skillSlots;
            }
        }

    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}