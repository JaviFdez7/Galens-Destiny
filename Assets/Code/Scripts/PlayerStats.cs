using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI levelText;  
    public TextMeshProUGUI tokenText; 
    public TextMeshProUGUI skillSlotsMaxText; 
    public TextMeshProUGUI skillSlotsText; 
    
    public TextMeshProUGUI vitalityText;
    public TextMeshProUGUI damageText; 
    public TextMeshProUGUI attackSpeedText; 
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI energyText; 
    public TextMeshProUGUI weightText; 
    public TextMeshProUGUI movementSpeedTex; 


    public void UIText()
    {
        levelText.text = "" + PlayerData.instance.level;
        tokenText.text = "" + PlayerData.instance.token;
        //skillSlotsMaxText.text = "" + skillSlotsMax;
        //skillSlotsText.text = "" + skillSlots;
        vitalityText.text = "" + PlayerData.instance.vitality;
        damageText.text = "" + PlayerData.instance.damage;
        attackSpeedText.text = "" + PlayerData.instance.attackSpeed;
        armorText.text = "" + PlayerData.instance.armor;
        energyText.text = "" + PlayerData.instance.energy;
        weightText.text = "" + PlayerData.instance.weight;
        movementSpeedTex.text = "" + PlayerData.instance.movementSpeed;
    }

    void Update()
    {
        UIText();
    }

}