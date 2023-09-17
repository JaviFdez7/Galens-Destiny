using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeTree : MonoBehaviour
{
    public PlayerStats playerStats;
    public PauseMenu pauseMenu;

    public class Leaf
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int cost { get; set; }
        public int parentId { get; set; }
        public bool unlocked { get; set; }
        public bool available { get; set; }

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
    }

    public List<Leaf> allLeafObjects = new List<Leaf>();    
    public void Initialize()
    {
        Leaf leaf0 = new Leaf(0, "Upgrade 0", "Opens the secret door.", 0, -1, true, false);
        Leaf leaf1 = new Leaf(1, "Upgrade 1", "Opens the secret door.", 1, 0, false, true);
        Leaf leaf2 = new Leaf(2, "Upgrade 2", "Opens the secret door.", 1, 1, false, false);
        Leaf leaf3 = new Leaf(3, "Upgrade 3", "Opens the secret door.", 1, 1, false, false);
        Leaf leaf4 = new Leaf(4, "Upgrade 4", "Opens the secret door.", 2, 2, false, false);
        Leaf leaf5 = new Leaf(5, "Upgrade 5", "Opens the secret door.", 2, 2, false, false);
        Leaf leaf6 = new Leaf(6, "Upgrade 6", "Opens the secret door.", 3, 3, false, false);        

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
                    TryToUnlockAnNonUnlockableUpgrade(0);
                }
            } else
            {
                TryToUnlockAnNonUnlockableUpgrade(1);
            }
        } else 
        {
            TryToUnlockAnNonUnlockableUpgrade(2);
        }
    }


    private string nonUnlockableUpgradeText;
    private void TryToUnlockAnNonUnlockableUpgrade(int errorControlCode) // else in UnlockUpgrade
    {
        pauseMenu.OpenWarningMenu();
        if(errorControlCode == 0) // if(playerStats.token >= upgradeLeaf.cost) 
        {
            nonUnlockableUpgradeText = "Upgrade non-unlockable: insufficient tokens";
        } else if(errorControlCode == 1) // if(upgradeLeaf.available)
        {
            nonUnlockableUpgradeText = "Upgrade non-unlockable: unavailable upgrade";
        } else if(errorControlCode == 2) // if(!upgradeLeaf.unlocked)
        {
            nonUnlockableUpgradeText = "Upgrade non-unlockable: upgrade already unlocked";
        }
    }

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

    public TextMeshProUGUI warningMessage;

    public TextMeshProUGUI availableTokensText;

    public void UIText()
    {
        warningMessage.text = "" + nonUnlockableUpgradeText;
        availableTokensText.text = "Tokens: " + playerStats.token.ToString();
    }
}
