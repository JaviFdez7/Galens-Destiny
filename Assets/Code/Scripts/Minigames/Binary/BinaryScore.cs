using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BinaryScore : MonoBehaviour
{
    public static BinaryScore instance;

    public int currentScore = 1000;
    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentScoreText.text = currentScore.ToString();
        currentScoreTextInEndPanel.text = currentScore.ToString();
    }

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentScoreTextInEndPanel;
    public void CalculateCurrentScore(int minimumNumberOfClicksInTheLevel, int currentNumberOfClicks)
    {
        int negativePoints = 25;

        if(currentNumberOfClicks > minimumNumberOfClicksInTheLevel)
            if(currentScore != 0)
                if((currentScore-negativePoints)>=0)
                    SubstractPoints(negativePoints);
    }

    public void SubstractPoints(int negativePoints)
    {
        currentScore -= negativePoints;
        currentScore = Math.Max(0, currentScore);
        currentScoreText.text = currentScore.ToString();
        currentScoreTextInEndPanel.text = currentScore.ToString();
    }

}


