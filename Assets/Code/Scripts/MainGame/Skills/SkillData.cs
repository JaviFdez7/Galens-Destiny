using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static SkillsMenu;

public class SkillData : MonoBehaviour
{
    public List<Skill> activeSkills = new List<Skill> { null, null, null };
    public Skill passiveActiveSkill = null;
    public List<Skill> allSkillObjects = new List<Skill>();
    public List<Sprite> skillImages; 
    public Dictionary<KeyCode, IExecuteCommand> commands = new Dictionary<KeyCode, IExecuteCommand>();

    public static SkillData instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Initialize();
    }

    public void Initialize()
    {
        // ================== HIDDEN SKILLS (Mouse) ==================

        //Setting the skills unvisible
        GameObject shootGo = GameObject.Find("ShootSkill");
        SpriteRenderer sp = shootGo.GetComponentInChildren<SpriteRenderer>();
        if (sp != null) sp.enabled = false;

    

        GameObject drillGo = GameObject.Find("DrillSkill");
        SpriteRenderer spDrill = drillGo.GetComponentInChildren<SpriteRenderer>();
        if (spDrill != null) spDrill.enabled = false;




        // ================== SKILLS ==================

        IExecuteCommand shootSkill = shootGo.GetComponent<ShootSkill>();

        IExecuteCommand drillSkill = drillGo.GetComponent<DrillSkill>();

        GameObject emptyGo = GameObject.Find("EmptySkill");
        IExecuteCommand emptySkill = emptyGo.GetComponent<EmptySkill>();

        GameObject bomberSkillGo = GameObject.Find("BomberSkill");
        IExecuteCommand bomberSkillCommand = bomberSkillGo.GetComponent<IExecuteCommand>();

        GameObject shieldSkillGo = GameObject.Find("ShieldSkill");
        IExecuteCommand shieldSkillCommand = shieldSkillGo.GetComponent<IExecuteCommand>();
        
        // ================== SKILL ACTIVE ==================
        Skill skill0 = new Skill(0, SkillEnum.Shoot, "Electric Gun", "Using a mini nuclear reactor to generate electricity, this weapon can be used for both offense and defense.", "Shoots a powerful electric bolt", 1, true, false, 5, skillImages[0], bomberSkillCommand);

        Skill skill1 = new Skill(1, SkillEnum.Drill, "Strategic Foresight", "Anticipating trends, assessing risks, and designing long-term strategies for personal or business success.", "Generates a large storm that pushes enemies", 1, false, false, 5, skillImages[1], drillSkill);
        Skill skill2 = new Skill(2, SkillEnum.Bomb, "Bombastic SideEye", "Approaching problems from diverse perspectives is a great strategy. However, sometimes a little explosion is all you need.", "A gadget that goes 'BOOMMM'", 2, false, false, 5, skillImages[2], bomberSkillCommand);
        Skill skill3 = new Skill(3, SkillEnum.Shield, "Nija Turtle", "When in doubt, shield it out. A strong defense is the best offense.", "Generates a shield that blocks incoming attacks", 2, false, false, 5, skillImages[3], shieldSkillCommand);

        // ================== SKILL PASSIVE ==================

        Skill skill4 = new Skill(4, SkillEnum.Empty, "Empty", "Empty", "Empty", 0, false, true, 0, skillImages[4], emptySkill);


        allSkillObjects.Add(skill0);
        allSkillObjects.Add(skill1);
        allSkillObjects.Add(skill2);
        allSkillObjects.Add(skill3);
        allSkillObjects.Add(skill4);

    }
}