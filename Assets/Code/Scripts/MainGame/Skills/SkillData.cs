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
        GameObject shootGo = GameObject.Find("ShootSkill");
        SpriteRenderer sp = shootGo.GetComponentInChildren<SpriteRenderer>();
        if (sp != null) sp.enabled = false;

        IExecuteCommand shootSkill = shootGo.GetComponent<ShootSkill>();
    

        GameObject drillGo = GameObject.Find("DrillSkill");
        SpriteRenderer spDrill = drillGo.GetComponentInChildren<SpriteRenderer>();
        if (spDrill != null) spDrill.enabled = false;

        IExecuteCommand drillSkill = drillGo.GetComponent<DrillSkill>();


        // ================== SKILLS ==================

        GameObject skillInPlayerTransform = GameObject.Find("BomberSkill");
        IExecuteCommand bomberSkillCommand = skillInPlayerTransform.GetComponent<IExecuteCommand>();
        

        Skill skill0 = new Skill(0, SkillEnum.Shoot, "Electric Gun", "Using a mini nuclear reactor to generate electricity, this weapon can be used for both offense and defense.", "Shoots a powerful electric bolt", 1, true, false, 5, skillImages[0], bomberSkillCommand);

        Skill skill1 = new Skill(1, SkillEnum.Drill, "Strategic Foresight", "Anticipating trends, assessing risks, and designing long-term strategies for personal or business success.", "Generates a large storm that pushes enemies", 1, false, false, 5, skillImages[1], drillSkill);
        Skill skill2 = new Skill(2, SkillEnum.Bomb, "Bombastic SideEye", "Approaching problems from diverse perspectives is a great strategy. However, sometimes a little explosion is all you need.", "A gadget that goes 'BOOMMM'", 2, false, false, 5, skillImages[2], bomberSkillCommand);
        Skill skill3 = new Skill(3, SkillEnum.Empty, "Resilient Adaptability", "Adapting flexibly to changes, overcoming challenges with emotional and mental resilience.", "Summon  3 littles robots", 2, false, false, 5, skillImages[3], bomberSkillCommand);
        Skill skill4 = new Skill(4, SkillEnum.Empty, "Persuasive Communication", "Ethically influencing through compelling arguments, using empathy and integrity to achieve consensus and positive impact.", "Throw a big energy ball", 2, false, false, 5, skillImages[4], bomberSkillCommand);
        Skill skill5Passive = new Skill(5, SkillEnum.Empty, "Fire Punch", "The skill to control and manipulate flames with precision, used for both defensive and offensive purposes. Requires mental focus and a deep understanding of fire dynamics.", "Expert fire control for offense and defense.", 2, false, true, 5, skillImages[5], bomberSkillCommand);
        Skill skill6 = new Skill(6, SkillEnum.Empty, "LOOOL", "Locked Skill", "Locked Skill", 2, false, false, 5, skillImages[6], bomberSkillCommand);
        Skill skill7 = new Skill(7, SkillEnum.Empty, "Locked Skill 2", "Locked Skill", "Locked Skill", 2, false, false, 5, skillImages[7], bomberSkillCommand);
        Skill skill8Passive = new Skill(8, SkillEnum.Empty, "Locked Skill 3", "Locked Skill", "Locked Skill", 2, false, true, 5, skillImages[8], bomberSkillCommand);
        Skill skill9Passive = new Skill(9, SkillEnum.Empty, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, 5, skillImages[9], bomberSkillCommand);
        Skill skill10Passive = new Skill(10, SkillEnum.Empty, "Locked Skill", "Locked Skill", "Locked Skill", 1, false, true, 5, skillImages[10], bomberSkillCommand);
        Skill skill11Passive = new Skill(11, SkillEnum.Empty, "Locked Skill", "Locked Skill", "Locked Skill", 1, false, true, 5, skillImages[11], bomberSkillCommand);
        Skill skill12Passive = new Skill(12, SkillEnum.Empty, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, 5, skillImages[12], bomberSkillCommand);

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
}