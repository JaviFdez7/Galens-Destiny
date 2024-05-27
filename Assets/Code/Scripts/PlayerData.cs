using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool testMode;
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
    public static PlayerData instance;

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