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




        // ================== SKILL ACTIVE ==================
        Skill skill0 = new Skill(0, SkillEnum.Shoot, "Electric Gun", "Using a mini nuclear reactor to generate electricity, this weapon can be used for both offense and defense.", "Shoots a powerful electric bolt", 1, true, false, 5, skillImages[0], "ShootSkill");

        Skill skill1 = new Skill(1, SkillEnum.Drill, "Strategic Foresight", "Anticipating trends, assessing risks, and designing long-term strategies for personal or business success.", "Generates a large storm that pushes enemies", 1, false, false, 5, skillImages[1], "DrillSkill");
        Skill skill2 = new Skill(2, SkillEnum.Bomb, "Bombastic SideEye", "Approaching problems from diverse perspectives is a great strategy. However, sometimes a little explosion is all you need.", "A gadget that goes 'BOOMMM'", 2, false, false, 5, skillImages[2], "BomberSkill");
        Skill skill3 = new Skill(3, SkillEnum.Shield, "Nija Turtle", "When in doubt, shield it out. A strong defense is the best offense.", "Generates a shield that blocks incoming attacks", 2, false, false, 5, skillImages[3], "ShieldSkill");

        // ================== SKILL PASSIVE ==================

        Skill skill4 = new Skill(4, SkillEnum.Heal, "Regenerative Healing", "Robots are not immune to damage. But they can heal themselves.", "Heals the player", 3, false, true, 5, skillImages[4], "HealSkill");


        allSkillObjects.Add(skill0);
        allSkillObjects.Add(skill1);
        allSkillObjects.Add(skill2);
        allSkillObjects.Add(skill3);
        allSkillObjects.Add(skill4);

    }

    /// <summary>
    /// Regenerates the commands for the active skills
    /// This is becuse the commands are destroyed when the scene is reloaded
    /// This method is called in the Health script on start function
    /// </summary>
    public void RegenerateCommands()
    {
        commands.Clear();
        Dictionary<int, KeyCode> keyCodes = new Dictionary<int, KeyCode>
        {
            {0, KeyCode.Q},
            {1, KeyCode.E},
            {2, KeyCode.C},
        };
        for (int i = 0; i < activeSkills.Count; i++)
        {
            if (activeSkills[i] != null)
            {
                commands.Add(keyCodes[i], activeSkills[i].getSkillCommand());
            }
        }

        // Bind again the shoot skill and the drill skill,
        // You can look the PickSkill script to see how the skills are binded

        GameObject shootSkillTransform = GameObject.Find("ShootSkill");
        SpriteRenderer sp = shootSkillTransform.GetComponentInChildren<SpriteRenderer>();
        if (sp != null && sp.enabled)
        {
            IExecuteCommand shootSkill = shootSkillTransform.GetComponent<ShootSkill>();
            this.commands.Add(KeyCode.Mouse0, shootSkill);
        }

        GameObject drillSkillTransform = GameObject.Find("DrillSkill");
        SpriteRenderer spDrill = drillSkillTransform.GetComponentInChildren<SpriteRenderer>();
        if (spDrill != null && spDrill.enabled)
        {
            IExecuteCommand drillSkill = drillSkillTransform.GetComponent<DrillSkill>();
            commands.Add(KeyCode.Mouse1, drillSkill);
        }
    }
}