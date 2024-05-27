using System.Collections.Generic;
using UnityEngine;

public class MinigameSetupData : MonoBehaviour
{
    public int history;
    public SkillEnum skillName;   

    public static MinigameSetupData instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}