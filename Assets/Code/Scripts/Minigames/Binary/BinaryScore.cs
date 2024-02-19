using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BinaryScore : MonoBehaviour
{
    private int currentScore = 1000;
    public TextMeshProUGUI currentScoreText;
    public void CalculateCurrentScore(int minimumNumberOfClicksInTheHistory, int currentNumberOfClicks)
    {
        if(currentNumberOfClicks > minimumNumberOfClicksInTheHistory)
            if(currentScore != 0)
                currentScore -= 50;
        currentScoreText.text = "Current Score: " + currentScore.ToString();
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
