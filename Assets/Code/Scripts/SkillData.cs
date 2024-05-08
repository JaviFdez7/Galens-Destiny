using System.Collections.Generic;
using UnityEngine;
using static SkillsMenu;

public class SkillData : MonoBehaviour
{
    public List<Skill> activeSkills = new List<Skill> { null, null, null };
    public Skill passiveActiveSkill = null;
    public List<Skill> allSkillObjects = new List<Skill>();
    public List<Sprite> skillImages;
 

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
        Skill skill0 = new Skill(0, "Emotional Insight", "Recognizing and managing one's own and others' emotions, fostering healthy relationships and making conscientious decisions.", "Kill all enemies around the IA's mate", 1, true, false, skillImages[0], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill1 = new Skill(1, "Strategic Foresight", "Anticipating trends, assessing risks, and designing long-term strategies for personal or business success.", "Generates a large storm that pushes enemies", 1, true, false, skillImages[1], new SkillCommand(new StrategicForesightSkill()));
        Skill skill2 = new Skill(2, "Multidimensional Creativity", "Approaching problems from diverse perspectives, merging ideas to generate innovative solutions.", "Teleport in a range's distance", 2, true, false, skillImages[2], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill3 = new Skill(3, "Resilient Adaptability", "Adapting flexibly to changes, overcoming challenges with emotional and mental resilience.", "Summon  3 littles robots", 2, true, false, skillImages[3], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill4 = new Skill(4, "Persuasive Communication", "Ethically influencing through compelling arguments, using empathy and integrity to achieve consensus and positive impact.", "Throw a big energy ball", 2, false, false, skillImages[4], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill5Passive = new Skill(5, "Fire Punch", "The skill to control and manipulate flames with precision, used for both defensive and offensive purposes. Requires mental focus and a deep understanding of fire dynamics.", "Expert fire control for offense and defense.", 2, true, true, skillImages[5], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill6 = new Skill(6, "LOOOL", "Locked Skill", "Locked Skill", 2, false, false, skillImages[6], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill7 = new Skill(7, "Locked Skill 2", "Locked Skill", "Locked Skill", 2, false, false, skillImages[7], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill8Passive = new Skill(8, "Locked Skill 3", "Locked Skill", "Locked Skill", 2, false, true, skillImages[8], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill9Passive = new Skill(9, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, skillImages[9], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill10Passive = new Skill(10, "Locked Skill", "Locked Skill", "Locked Skill", 1, true, true, skillImages[10], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill11Passive = new Skill(11, "Locked Skill", "Locked Skill", "Locked Skill", 1, true, true, skillImages[11], new SkillCommand(new EmotionalInsightSkill()));
        Skill skill12Passive = new Skill(12, "Locked Skill", "Locked Skill", "Locked Skill", 2, false, true, skillImages[12], new SkillCommand(new EmotionalInsightSkill()));

        SkillData.instance.allSkillObjects.Add(skill0);
        SkillData.instance.allSkillObjects.Add(skill1);
        SkillData.instance.allSkillObjects.Add(skill2);
        SkillData.instance.allSkillObjects.Add(skill3);
        SkillData.instance.allSkillObjects.Add(skill4);
        SkillData.instance.allSkillObjects.Add(skill5Passive);
        SkillData.instance.allSkillObjects.Add(skill6);
        SkillData.instance.allSkillObjects.Add(skill7);
        SkillData.instance.allSkillObjects.Add(skill8Passive);
        SkillData.instance.allSkillObjects.Add(skill9Passive);
        SkillData.instance.allSkillObjects.Add(skill10Passive);
        SkillData.instance.allSkillObjects.Add(skill11Passive);
        SkillData.instance.allSkillObjects.Add(skill12Passive);
    }
}