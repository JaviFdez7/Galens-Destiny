using System.Collections;
using TMPro;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static Energy instance;

    private Coroutine regenerationCoroutine;
    public float regenerationDelay = 3.0f; // Waiting for start the regeneration
    public int regenerationAmount = 1; // Regeneration per interval
    public float regenerationInterval = 0.2f; // 

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    
    private void Start()
    {
        EnergyBar.instance.InitializeEnergyBar(PlayerData.instance.maxEnergy, PlayerData.instance.currentEnergy);
    }

    private void Update()
    {
        UIText();
    }

    public void SpendEnergy(int usedEnergy)
    {
        PlayerData.instance.currentEnergy -= usedEnergy;
        PlayerData.instance.currentEnergy = Mathf.Clamp(PlayerData.instance.currentEnergy, 0, PlayerData.instance.maxEnergy);
        EnergyBar.instance.ChangeCurrentEnergy(PlayerData.instance.currentEnergy);

        // Restart the regeneration Coroutine
        if (regenerationCoroutine != null)
        {
            StopCoroutine(regenerationCoroutine);
        }
        regenerationCoroutine = StartCoroutine(RegenerateEnergyAfterDelay());
    }

    private IEnumerator RegenerateEnergyAfterDelay()
    {
        yield return new WaitForSeconds(regenerationDelay);
        while (PlayerData.instance.currentEnergy < PlayerData.instance.maxEnergy)
        {
            PlayerData.instance.currentEnergy += regenerationAmount;
            PlayerData.instance.currentEnergy = Mathf.Clamp(PlayerData.instance.currentEnergy, 0, PlayerData.instance.maxEnergy);
            EnergyBar.instance.ChangeCurrentEnergy(PlayerData.instance.currentEnergy);
            yield return new WaitForSeconds(regenerationInterval);
        }
        regenerationCoroutine = null;
    }

    public TextMeshProUGUI currentEnergyBarMaxEnergy;

    public void UIText()
    {
        currentEnergyBarMaxEnergy.text = PlayerData.instance.currentEnergy + " / " + PlayerData.instance.maxEnergy;
    }
}
