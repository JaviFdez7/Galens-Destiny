using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool testMode;


    public Vector2 lastCheckPoint;

    public List<int> keys = new List<int>();


    public int maxHealth = 100;
    public int currentHealth;

    public int maxEnergy = 100;
    public int currentEnergy;

    public int currentExp; // player's current experience
    public int maxExp = 10; // exp required for the next level


    public int level; // player's current level
    public int token; // tokens give you the possibility to advance in the skill tree and improve your character
    public int skillSlotsMax; // determines the maximum number of points that your skills can add
    public int skillSlots; // determines the number of skill points that player have
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
        ResetPlayerData();
        DontDestroyOnLoad(gameObject);
    }

    public void ResetPlayerData()
    {
        this.lastCheckPoint = new Vector2(-7, 5);
        this.maxHealth = 100;
        this.currentHealth = 100;
        HealthBar.instance.InitializeHealthBar(this.maxHealth, this.currentHealth);
        this.maxEnergy = 100;
        this.currentEnergy = 100;
        this.currentExp = 0;
        this.maxExp = 10;
        this.level = 1;
        this.token = 0;
        this.skillSlotsMax = 0;
        this.skillSlots = 0;
        this.vitality = 0;
        this.damage = 0;
        this.attackSpeed = 0;
        this.armor = 0;
        this.energy = 0;
        this.weight = 0;
        this.movementSpeed = 0;
    }



}