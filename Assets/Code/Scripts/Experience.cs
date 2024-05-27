using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public int currentExp; // player's current experience
    public int maxExp = 10; // exp required for the next level
    public ExperienceBar experienceBar;

    void SubirExp(int exp)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentExp += 2;
        }
        if(!PlayerData.instance.testMode) 
        {
            currentExp += exp;
        }

        while(currentExp >= maxExp)
        {
            PlayerData.instance.level++;
            currentExp = 0 + currentExp - maxExp;
            maxExp = Mathf.RoundToInt(maxExp * 1.1f);
            PlayerData.instance.token++;
        }
        experienceBar.ChangeMaxExperience(maxExp);
        experienceBar.ChangeCurrentExperience(currentExp);
    }

    // Start is called before the first frame update
    void Start()
    {
        experienceBar.InitializeExperienceBar(currentExp, maxExp);
    }

    // Update is called once per frame
    void Update()
    {
        UIText();
        if(PlayerData.instance.testMode)
        {
            SubirExp(2);
        }
    }

    public TextMeshProUGUI currentExpBarMaxExp;

    public void UIText()
    {
        currentExpBarMaxExp.text = "" + currentExp + " / " + maxExp;
    }
}
