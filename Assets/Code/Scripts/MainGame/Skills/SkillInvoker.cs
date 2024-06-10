using UnityEngine;
using System.Collections.Generic;
using static SkillsMenu;

public class SkillInvoker : MonoBehaviour
{
    public static SkillInvoker instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void AddNewCommand(KeyCode keyCode, SkillCommand skillCommand)
    {
        SkillData.instance.commands.Remove(keyCode);
        SkillData.instance.commands.Add(keyCode, skillCommand);
    }

    public void DeleteExistingCommandFromKeyCode(KeyCode keyCode)
    {
        SkillData.instance.commands.Remove(keyCode);
    }

    private void Update()
    {
        foreach (var kvp in SkillData.instance.commands)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                kvp.Value.Execute();
            }
        }
    }
}

public interface ICommand
{
    void Execute();
}

public class SkillCommand : ICommand
{
    private ISkill skill;

    public SkillCommand(ISkill skill)
    {
        this.skill = skill;
    }
    public void Execute()
    {
        skill.Activate();
    }
}

public interface ISkill
{
    void Activate();
}

