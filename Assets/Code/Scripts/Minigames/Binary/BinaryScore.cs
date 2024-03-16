using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BinaryScore : MonoBehaviour
{
    private int currentScore = 1000;
    public TextMeshProUGUI currentScoreText;
    public void CalculateCurrentScore(int minimumNumberOfClicksInTheLevel, int currentNumberOfClicks)
    {
        int negativePoints = 25;

        if(currentNumberOfClicks > minimumNumberOfClicksInTheLevel)
            if(currentScore != 0)
                if((currentScore-negativePoints)>=0)
                    currentScore -= negativePoints;
                else
                    currentScore = 0;
            
        currentScoreText.text = "Current Score: " + currentScore.ToString();
    }

    public void SubstractPoints(int negativePoints)
    {
        if((currentScore-negativePoints)>=0)
            currentScore -= negativePoints;
        else
            currentScore = 0;

        currentScoreText.text = "Current Score: " + currentScore.ToString();
    }

}
