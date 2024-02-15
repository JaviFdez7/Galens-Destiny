using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigitPanel : MonoBehaviour
{
    public int index;
    public TextMeshProUGUI DigitText;

    public void UpdateDigitPanel(string newDigitValue)
    {
        DigitText.text = newDigitValue;
    }
}
