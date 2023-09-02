using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int level; // player's current level
    public float currentExp; // player's current experience
    public float expMax; // exp required for the next level
    public int token; // tokens give you the possibility to advance in the skill tree and improve your character
    public int skillSlots; // determines the maximum number of points that your skills can add
    
    public int vitality; // makes the character's health increase
    public int damage; // "" damage increase
    public int attackSpeed; // "" attackSpeed increase 
    public int armor; // "" armor increase -> resistance to enemies attacks
    public int energy; // "" energy (mana) increase -> energy is used to cast abilities
    public int weight; // "" weight increase -> greater weight, more objects you can carry
    public int movementSpeed; // "" movementSpeed increase

    [SerializeField] public bool testMode;

    public Text levelText; 
    public Text currentExpText; 
    public Text expMaxText; 
    public Text tokenText; 
    public Text skillSlotsText; 
    
    public Text vitalityText;
    public Text damageText; 
    public Text attackSpeedText; 
    public Text armorText;
    public Text energyText; 
    public Text weightText; 
    public Text movementSpeedTex; 


    void SubirExp(float exp)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentExp += 10;
        }
        if(!testMode) 
        {
            currentExp += exp;
        }

        while(currentExp >= expMax)
        {
            level++;
            currentExp = 0 + currentExp - expMax;
            expMax = Mathf.RoundToInt(expMax * 1.1f);
            token++;
        }
    }

    public void UIText()
    {
        levelText.text = ""+level;
    }

    void Update()
    {
        if(testMode)
        {
            SubirExp(10);
        }
        UIText();
    }

}