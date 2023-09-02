using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondarySkillsTree : MonoBehaviour
{
    public class LeafObject
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public int parentId { get; private set; }
        public bool unlocked { get; private set; }
        public bool available { get; private set; }

        public LeafObject(int id, string name, string description, int parentId, bool unlocked, bool available)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.parentId = parentId;
            this.unlocked = unlocked;
            this.available = available;
        }
    }

    public List<LeafObject> allLeafObjects = new List<LeafObject>();
    
    public void CreateTree()
    {
        LeafObject myLeaf = new LeafObject(1, "Key", "Opens the secret door.", 0, false, true);

        allLeafObjects.Add(myLeaf);
    }

    public LeafObject getLeafById(int id)
    {
        LeafObject res = null;
        foreach (LeafObject l in allLeafObjects)
        {
            if(l.id==id)
            {
                res = l;
            }
        }
        return res;
    }

    public void AvailableLeafs()
    {
        foreach (LeafObject l in allLeafObjects)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
