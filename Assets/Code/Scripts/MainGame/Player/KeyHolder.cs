using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public List<int> keys = new();

    public void AddKey(int key)
    {
        keys.Add(key);
    }
    public void RemoveKey(int key)
    {
        keys.Remove(key);
    }

    public bool HasKey(int key)
    {
        if (key == -1) return true;
        Debug.Log("Checking if player has key: " + key + " keys: " + string.Join(", ", keys));
        return keys.Contains(key);
    }
}
