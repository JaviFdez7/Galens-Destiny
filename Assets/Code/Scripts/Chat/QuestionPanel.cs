using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ChatManager;

public class QuestionPanel : MonoBehaviour
{
    public TextMeshProUGUI currentText;

    public void CreateQuestionPanel(Question question)
    {
        if(question.covered)
            currentText.text = question.question;
        else
            currentText.text = question.answer;
    }

    public void ShowAnswerPanel(string minigame, Question question, List<Question> questions)
    {
        
        GetComponentInParent<SubtractScore>().SubtractScoreOfTheActiveMinigame(minigame, question);
        question.covered = false;

        ChatLoyout chatLoyout = GetComponentInParent<ChatLoyout>();
        chatLoyout.DestroyQuestionGrid();
        chatLoyout.BuildQuestionGrid(minigame, questions);
    }
}