using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int level; // player's current level
    public int token; // tokens give you the possibility to advance in the skill tree and improve your character
    public int skillSlotsMax; // determines the maximum number of points that your skills can add
    public int skillSlots; // determines the number of skill points in use 
    public int vitality; // makes the character's health increase
    public int damage; // "" damage increase
    public int attackSpeed; // "" attackSpeed increase 
    public int armor; // "" armor increase -> resistance to enemies attacks
    public int energy; // "" energy (mana) increase -> energy is used to cast abilities
    public int weight; // "" weight increase -> greater weight, more objects you can carry
    public int movementSpeed; // "" movementSpeed increase

    [SerializeField] public bool testMode;

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
        levelText.text = "" + level;
        tokenText.text = "" + token;
        //skillSlotsMaxText.text = "" + skillSlotsMax;
        //skillSlotsText.text = "" + skillSlots;
        vitalityText.text = "" + vitality;
        damageText.text = "" + damage;
        attackSpeedText.text = "" + attackSpeed;
        armorText.text = "" + armor;
        energyText.text = "" + energy;
        weightText.text = "" + weight;
        movementSpeedTex.text = "" + movementSpeed;
    }

    void Update()
    {
        UIText();
    }

}