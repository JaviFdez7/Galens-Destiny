using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GameObject HUDPanel;

    public static HUD instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    public void ActiveHUD()
    {
        HUDPanel.SetActive(true);
    }

    public void DisableHUD()
    {
        HUDPanel.SetActive(false);
    }
}
