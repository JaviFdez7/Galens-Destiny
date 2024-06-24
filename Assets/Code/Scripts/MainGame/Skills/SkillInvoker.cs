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

    public void AddNewCommand(KeyCode keyCode, IExecuteCommand command)
    {
        SkillData.instance.commands.Remove(keyCode);
        SkillData.instance.commands.Add(keyCode, command);
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
                if(!PauseMenu.instance.isPaused)
                    kvp.Value.Execute();
            }
        }
    }
}

public interface IExecuteCommand
{
    void Execute();
}



