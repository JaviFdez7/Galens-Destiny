using UnityEngine;
using System.Collections.Generic;

public class SkillInvoker : MonoBehaviour
{
    public Energy energy;
    public Dictionary<KeyCode, ICommand> commands = new Dictionary<KeyCode, ICommand>();
    public void AddNewCommand(KeyCode keyCode, SkillCommand skillCommand)
    {
        commands.Remove(keyCode);
        commands.Add(keyCode, skillCommand);
    }

    public void DeleteExistingCommandFromKeyCode(KeyCode keyCode)
    {
        commands.Remove(keyCode);
    }

    private void Update()
    {
        foreach (var kvp in commands)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                kvp.Value.Execute(energy);
            }
        }
    }
}

public interface ICommand
{
    void Execute(Energy energy);
}

public class SkillCommand : ICommand
{
    private ISkill skill;

    public SkillCommand(ISkill skill)
    {
        this.skill = skill;
    }
    public void Execute(Energy energy)
    {
        skill.Activate(energy);
    }
}

public interface ISkill
{
    
    void Activate(Energy energy);
}

