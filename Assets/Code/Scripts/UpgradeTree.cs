using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Upgrade;

public class UpgradeTree : MonoBehaviour
{
    public PlayerStats playerStats;
    public WarningScreenController warningScreenController;


    public class Leaf
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int cost { get; set; }
        public int parentId { get; set; }
        public bool unlocked { get; set; }
        public bool available { get; set; }
        public List<IStatStrategy> statStrategies = new List<IStatStrategy>();

        public Leaf(int id, string name, string description, int cost, int parentId, bool unlocked, bool available)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.cost = cost;
            this.parentId = parentId;
            this.unlocked = unlocked;
            this.available = available;
        }

        public void AddStatStrategy(IStatStrategy strategy)
        {
            statStrategies.Add(strategy);
        }

        public void ApplyStatStrategies(PlayerStats playerStats)
        {
            foreach (var strategy in statStrategies)
            {
                strategy.ApplyPermanentUpgrade(playerStats);
            }
        }

        public string ResumeToString(PlayerStats playerStats)
        {
            string res = "";
            for(int i = 0; i < statStrategies.Count; i++)
            {
                res += statStrategies[i].ResumeToString(playerStats, available);
                if(statStrategies.Count-1 > i)
                {
                    res += "\n";
                }
            }
            return res;
        }
    }

    public List<Leaf> allLeafObjects = new List<Leaf>();    
    public void Initialize()
    {
        Leaf leaf0 = new Leaf(0, "Upgrade 0", "Opens the secret door.", 0, -1, true, false);
        Leaf leaf1 = new Leaf(1, "King", "Opens the secret door.", 1, 0, false, true);
        IStatStrategy leaf1Strategy0 = StatStrategyFactory.CreateVitalityStrategy(4);
        IStatStrategy leaf1Strategy1 = StatStrategyFactory.CreateArmorStrategy(9);
        leaf1.AddStatStrategy(leaf1Strategy0);
        leaf1.AddStatStrategy(leaf1Strategy1);

        Leaf leaf2 = new Leaf(2, "Robot", "Opens the secret door.", 1, 1, false, false);
        IStatStrategy leaf2Strategy0 = StatStrategyFactory.CreateEnergyStrategy(5);
        leaf2.AddStatStrategy(leaf2Strategy0);

        Leaf leaf3 = new Leaf(3, "Mule", "Opens the secret door.", 1, 1, false, false);
        IStatStrategy leaf3Strategy0 = StatStrategyFactory.CreateMovementSpeedStrategy(14);
        IStatStrategy leaf3Strategy1 = StatStrategyFactory.CreateWeightStrategy(3);
        leaf3.AddStatStrategy(leaf3Strategy0);
        leaf3.AddStatStrategy(leaf3Strategy1);

        Leaf leaf4 = new Leaf(4, "Fighter", "Opens the secret door.", 2, 2, false, false);
        IStatStrategy leaf4Strategy0 = StatStrategyFactory.CreateDamageStrategy(6);
        IStatStrategy leaf4Strategy1 = StatStrategyFactory.CreateAttackSpeedStrategy(3);
        IStatStrategy leaf4Strategy2 = StatStrategyFactory.CreateEnergyStrategy(9);
        leaf4.AddStatStrategy(leaf4Strategy0);
        leaf4.AddStatStrategy(leaf4Strategy1);
        leaf4.AddStatStrategy(leaf4Strategy2);

        Leaf leaf5 = new Leaf(5, "Resistance +", "Opens the secret door.", 2, 2, false, false);
        IStatStrategy leaf5Strategy0 = StatStrategyFactory.CreateEnergyStrategy(25);
        leaf5.AddStatStrategy(leaf5Strategy0);

        Leaf leaf6 = new Leaf(6, "Push up", "Opens the secret door.", 3, 3, false, false);
        IStatStrategy leaf6Strategy0 = StatStrategyFactory.CreateArmorStrategy(4);
        IStatStrategy leaf6Strategy1 = StatStrategyFactory.CreateDamageStrategy(4);
        IStatStrategy leaf6Strategy2 = StatStrategyFactory.CreateVitalityStrategy(4);
        IStatStrategy leaf6Strategy3 = StatStrategyFactory.CreateMovementSpeedStrategy(4);
        leaf6.AddStatStrategy(leaf6Strategy0);
        leaf6.AddStatStrategy(leaf6Strategy1);
        leaf6.AddStatStrategy(leaf6Strategy2);     
        leaf6.AddStatStrategy(leaf6Strategy3);   

        allLeafObjects.Add(leaf0);
        allLeafObjects.Add(leaf1);
        allLeafObjects.Add(leaf2);
        allLeafObjects.Add(leaf3);
        allLeafObjects.Add(leaf4);
        allLeafObjects.Add(leaf5);
        allLeafObjects.Add(leaf6);
    }

    public void UnlockUpgrade(int leafId)
    {
        Leaf upgradeLeaf = allLeafObjects[leafId];
        if(!upgradeLeaf.unlocked)
        {
            if(upgradeLeaf.available)
            {
                if(playerStats.token >= upgradeLeaf.cost)
                {
                    playerStats.token -= upgradeLeaf.cost;
                    ExecuteUpgrade(leafId);
                    UpdateAvailableUpgrades(leafId);
                } else
                {
                    warningMessage = warningScreenController.TryToUnlockAnNonUnlockableUpgrade(0);     
                }
            } else
            {
                warningMessage = warningScreenController.TryToUnlockAnNonUnlockableUpgrade(1);
            }
        } else 
        {
            warningMessage = warningScreenController.TryToUnlockAnNonUnlockableUpgrade(2);
        }
    }

    private string warningMessage;

    private void UpdateAvailableUpgrades(int leafId)
    {
        allLeafObjects[leafId].unlocked = true;
        allLeafObjects[leafId].available = false;
        for(int i = 0; i < allLeafObjects.Count; i++)
        {
            if(allLeafObjects[i].parentId == leafId)
            {
                allLeafObjects[i].available = true;
            }
        }
    }

    private void ExecuteUpgrade(int leafId)
    {
        allLeafObjects[leafId].ApplyStatStrategies(playerStats);
    }

    // Start and Update -----------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        UIText();
    }

    // Update is called once per frame
    void Update()
    {
        UIText();
    }

    // UI Text ---------------------------------------------------------------------------------
    public TextMeshProUGUI warningText2;
    public TextMeshProUGUI availableTokensText;
    public TextMeshProUGUI upgrade1Name;
    public TextMeshProUGUI upgrade1Cost;
    public TextMeshProUGUI upgrade1Resume;
    public TextMeshProUGUI upgrade2Name;
    public TextMeshProUGUI upgrade2Cost;
    public TextMeshProUGUI upgrade2Resume;
    public TextMeshProUGUI upgrade3Name;
    public TextMeshProUGUI upgrade3Cost;
    public TextMeshProUGUI upgrade3Resume;
    public TextMeshProUGUI upgrade4Name;
    public TextMeshProUGUI upgrade4Cost;
    public TextMeshProUGUI upgrade4Resume;
    public TextMeshProUGUI upgrade5Name;
    public TextMeshProUGUI upgrade5Cost;
    public TextMeshProUGUI upgrade5Resume;
    public TextMeshProUGUI upgrade6Name;
    public TextMeshProUGUI upgrade6Cost;
    public TextMeshProUGUI upgrade6Resume;


    public void UIText()
    {
        List<string> allUpgradeName = new List<string>();
        List<string> allUpgradeCost = new List<string>();
        for(int i = 0; i < allLeafObjects.Count; i++)
        {
            allUpgradeName.Add(allLeafObjects[i].name);
            allUpgradeCost.Add(allLeafObjects[i].cost.ToString());
        }

        if(!allLeafObjects[1].unlocked)
        {
            upgrade1Name.text = "" + allUpgradeName[1];
            upgrade1Cost.text = "Cost: " + allUpgradeCost[1];
            upgrade1Resume.text = allLeafObjects[1].ResumeToString(playerStats); 
        } else
        {
            upgrade1Cost.text = "Unlocked";
            upgrade1Resume.gameObject.SetActive(false);        
        }

        if(!allLeafObjects[2].unlocked)
        {
            upgrade2Name.text = "" + allUpgradeName[2];
            upgrade2Cost.text = "Cost: " + allUpgradeCost[2];
            upgrade2Resume.text = allLeafObjects[2].ResumeToString(playerStats); 
        } else
        {
            upgrade2Cost.text = "Unlocked";
            upgrade2Resume.gameObject.SetActive(false);        
        }        
        
        if(!allLeafObjects[3].unlocked)
        {
            upgrade3Name.text = "" + allUpgradeName[3];
            upgrade3Cost.text = "Cost: " + allUpgradeCost[3];
            upgrade3Resume.text = allLeafObjects[3].ResumeToString(playerStats); 
        } else
        {
            upgrade3Cost.text = "Unlocked";
            upgrade3Resume.gameObject.SetActive(false);        
        } 

        if(!allLeafObjects[4].unlocked)
        {
            upgrade4Name.text = "" + allUpgradeName[4];
            upgrade4Cost.text = "Cost: " + allUpgradeCost[4];
            upgrade4Resume.text = allLeafObjects[4].ResumeToString(playerStats); 
        } else
        {
            upgrade4Cost.text = "Unlocked";
            upgrade4Resume.gameObject.SetActive(false);        
        } 

        if(!allLeafObjects[5].unlocked)
        {
            upgrade5Name.text = "" + allUpgradeName[5];
            upgrade5Cost.text = "Cost: " + allUpgradeCost[5];
            upgrade5Resume.text = allLeafObjects[5].ResumeToString(playerStats); 
        } else
        {
            upgrade5Cost.text = "Unlocked";
            upgrade5Resume.gameObject.SetActive(false);        
        } 

        if(!allLeafObjects[6].unlocked)
        {
            upgrade6Name.text = "" + allUpgradeName[6];
            upgrade6Cost.text = "Cost: " + allUpgradeCost[6];
            upgrade6Resume.text = allLeafObjects[6].ResumeToString(playerStats); 
        } else
        {
            upgrade6Cost.text = "Unlocked";
            upgrade6Resume.gameObject.SetActive(false);        
        } 

        availableTokensText.text = "Tokens: " + playerStats.token.ToString();
        warningText2.text = "" + warningMessage;
    }
}
