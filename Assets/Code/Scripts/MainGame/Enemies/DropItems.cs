using System;
using System.Collections.Generic;
using UnityEngine;

public static class DropItems 
{
    



    public static void Drop(Transform transform, float dropChance, List<GameObject> dropitems)
    {
        bool shouldDrop = UnityEngine.Random.value < dropChance; // 20% chance to drop items
        int elementToDrop = UnityEngine.Random.Range(1, dropitems.Count);
        if (shouldDrop)
        {
            GameObject.Instantiate(dropitems[elementToDrop], transform.position, Quaternion.identity);
        }
        //Experience
        GameObject.Instantiate(dropitems[0], transform.position, Quaternion.identity);
    }




}
