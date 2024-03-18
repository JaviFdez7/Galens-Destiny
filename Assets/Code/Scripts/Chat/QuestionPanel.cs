using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ChatManager;

public class QuestionPanel : MonoBehaviour
{
    public TextMeshProUGUI currentText;

    public void CreateQuestionPanel(Question question, Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
        if(question.covered)
            currentText.text = question.question; 
        else
        {
            currentText.text = question.answer;
            if(question.difficulty==1)
                GetComponent<Image>().color = new Color(102f / 255f, 214f / 255f, 90f / 255f, 1f);
            if(question.difficulty==2)
                GetComponent<Image>().color = new Color(248f / 255f, 238f / 255f, 71f / 255f, 1f);
            if(question.difficulty==3)
                GetComponent<Image>().color = new Color(255f / 255f, 129f / 255f, 145f / 255f, 1f);
        }
            
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