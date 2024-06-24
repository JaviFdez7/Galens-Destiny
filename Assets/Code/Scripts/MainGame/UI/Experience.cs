using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public void IncreaseExp(int exp)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerData.instance.currentExp += 2;
        }
        if(!PlayerData.instance.testMode) 
        {
            SoundMainManager.instance.PlayPick();
            PlayerData.instance.currentExp += exp;
        }

        while(PlayerData.instance.currentExp >= PlayerData.instance.maxExp)
        {
            PlayerData.instance.level++;
            PlayerData.instance.currentExp = 0 + PlayerData.instance.currentExp - PlayerData.instance.maxExp;
            PlayerData.instance.maxExp = Mathf.RoundToInt(PlayerData.instance.maxExp * 1.1f);
            PlayerData.instance.token++;
        }
        ExperienceBar.instance.ChangeMaxExperience(PlayerData.instance.maxExp);
        ExperienceBar.instance.ChangeCurrentExperience(PlayerData.instance.currentExp);
    }

    // Start is called before the first frame update
    void Start()
    {
        ExperienceBar.instance.InitializeExperienceBar(PlayerData.instance.currentExp, PlayerData.instance.maxExp);
    }

    // Update is called once per frame
    void Update()
    {
        UIText();
        if(PlayerData.instance.testMode)
        {
            IncreaseExp(2);
        }
    }

    public TextMeshProUGUI currentExpBarMaxExp;

    public void UIText()
    {
        currentExpBarMaxExp.text = "" + PlayerData.instance.currentExp + " / " + PlayerData.instance.maxExp;
    }
}
