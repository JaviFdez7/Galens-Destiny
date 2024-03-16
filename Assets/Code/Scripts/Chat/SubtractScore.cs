using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ChatManager;

public class SubtractScore : MonoBehaviour
{
    public BinaryScore binaryScore;
    // Add more minigamesScore class
    public void SubtractScoreOfTheActiveMinigame(string minigame, Question question)
    {
        if(question.covered == true){
            if(minigame == "binary")
            {
                binaryScore.SubstractPoints(question.lostPoints);
            }
            // Add more minigames
        }
    }
}