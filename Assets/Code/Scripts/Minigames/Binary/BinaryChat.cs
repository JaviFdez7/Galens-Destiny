using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ChatManager;

public class BinaryChat : MonoBehaviour, IMinigameChat
{
    public ChatManager chatManager;
    private List<Question> allQuestions = new List<Question>();


    public void SetupBinaryChat(params object[] optionalParams)
    {
            InitializeQuestions(optionalParams[1]);
            chatManager.InitializeChat("binary", QuestionUtils.Generate4RandomQuestions(allQuestions, 1, 2, 1));
    }

    public void InitializeQuestions(params object[] optionalParams)
    {
        allQuestions.Clear();

        Question question0 = new Question("FACIL1", "ANSWER", 1, 0);
        Question question1 = new Question("MEDIA1", "ANSWER", 2, 100);
        Question question2 = new Question("MEDIA2", "ANSWER", 2, 100);
        Question question3 = new Question("MEDIA3", "ANSWER", 2, 200);
        Question question4 = new Question("DIFICIL1", optionalParams[0].ToString(), 3, 200);
        Question question5 = new Question("DIFICIL2", optionalParams[0].ToString(), 3, 200);
        Question question6 = new Question("DIFICIL3", optionalParams[0].ToString(), 3, 200);
        Question question7 = new Question("FACIL2", optionalParams[0].ToString(), 1, 200);

        allQuestions.Add(question0);
        allQuestions.Add(question1);
        allQuestions.Add(question2);
        allQuestions.Add(question3);
        allQuestions.Add(question4);
        allQuestions.Add(question5);
        allQuestions.Add(question6);
        allQuestions.Add(question7);
    }
}
