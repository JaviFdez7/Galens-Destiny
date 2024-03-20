using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigitNumbersLayout : MonoBehaviour
{
    public Binary binary;
    public GridLayoutGroup digitGridPanel;
    public GameObject digitPanelPrefab;

    public void BuildDigitsGrid(int digits, List<int> binaryNumbers, List<DigitPanel> digitPanels)
    {
        for (int i = 0; i < digits; i++)
        {
            int index = i;
            GameObject digitGridElement = Instantiate(digitPanelPrefab, digitGridPanel.transform);
            digitGridElement.GetComponent<DigitPanel>().index = i;
            digitGridElement.GetComponent<Button>().onClick.AddListener(() => binary.ChangeDigitBinaryValue(index));
            digitGridElement.GetComponent<Button>().onClick.AddListener(() => digitGridElement.GetComponent<DigitPanel>().PlayButtonSound());
            digitGridElement.GetComponentInChildren<TextMeshProUGUI>().text = binaryNumbers[index].ToString();

            digitPanels.Add(digitGridElement.GetComponent<DigitPanel>());
        }
    }

    public void DestroyDigitsGrid()
    {
        foreach (Transform child in digitGridPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
