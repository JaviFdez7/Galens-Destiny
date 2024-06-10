using static SkillsMenu;

public static class SkillUtils {
    public static Skill GetActiveSkill(SkillEnum skillName)
    {
        Skill activeSkill = null;

        foreach (Skill skill in SkillData.instance.activeSkills)
            if (skill != null && skill.skillEnum == skillName)
            {
                activeSkill = skill;
                break;
            }

        return activeSkill;
    }
}
