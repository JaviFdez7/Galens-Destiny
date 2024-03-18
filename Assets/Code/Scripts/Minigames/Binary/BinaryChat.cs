using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static ChatManager;

public class BinaryChat : MonoBehaviour, IMinigameChat
{
    public ChatManager chatManager;
    private List<Question> allQuestions = new List<Question>();
    private List<Question> currentQuestions;

    // optionalParams in this order = [CorrectAnswer(), CorrectPositions(), IncorrectPositions(), CorrectValueOfARandomPosition(), FirstHalfOfTargetValue(), SecondHalfOfTargetValue()]
    public void SetupBinaryChat(params object[] optionalParams) 
    {
        InitializeQuestions(optionalParams);
        currentQuestions = QuestionUtils.GenerateRandomQuestions(allQuestions, 1, 2, 1);
        chatManager.InitializeChat("binary", currentQuestions);
    }

    public void UpdateQuestionsAnswers(params object[] optionalParams)
    {
        foreach(Question question in currentQuestions)
            UpdateCurrentAnswers(question, optionalParams);
        chatManager.InitializeChat("binary", currentQuestions);
    }

    public void InitializeQuestions(params object[] optionalParams)
    {
        allQuestions.Clear();

        Question question0diff1 = new Question(0, "How is the decimal value of a bit calculated in binary representation?", "Each bit represents 2 raised to the power of its position, from right to left, starting from 0. For example, if position 4 is 1, the value would be 2^4 = 16", 1, 0);
        Question question1diff1 = new Question(1, "How is a binary number converted to decimal?", "You add 2 raised to the position of each activated bit", 1, 0);
        Question question2diff1 = new Question(2, "What is the value of the least significant bit in binary representation?", "The value of the least significant bit is 2 raised to the power of position zero, which is 1", 1, 0);
        Question question3diff1 = new Question(3, "Why is binary logic fundamental in digital electronics?", "Binary logic (0 and 1) forms the foundation of digital electronics. Electronic circuits utilize electrical signals to represent digital information", 1, 0);
        
        allQuestions.Add(question0diff1);
        allQuestions.Add(question1diff1);
        allQuestions.Add(question2diff1);
        allQuestions.Add(question3diff1);

        Question question0diff2 = new Question(100, "How many positions are correct in the current binary sequence?", "You CURRENTLY have " + optionalParams[1].ToString() + " correct positions", 2, 50);
        Question question1diff2 = new Question(101, "How many positions are incorrect in the current binary sequence?", "You CURRENTLY have " + optionalParams[2].ToString() + " incorrect positions", 2, 50);
        Question question2diff2 = new Question(102, "What is the correct value of position " + ((string[])optionalParams[3])[0] + "?", "The correct value of the position " + ((string[])optionalParams[3])[0] + " is " + ((string[])optionalParams[3])[1], 2, 50);

        allQuestions.Add(question0diff2);
        allQuestions.Add(question1diff2);
        allQuestions.Add(question2diff2);   

        Question question0diff3 = new Question(200, "What is the correct binary sequence?", "The correct binary number is " + optionalParams[0].ToString(), 3, 200);
        Question question1diff3 = new Question(201, "What is the first half of the binary sequence?", "The first half of the binary sequence is " + optionalParams[4].ToString(), 3, 100);
        Question question2diff3 = new Question(202, "What is the second half of the binary sequence?", "The second half of the binary sequence is " + optionalParams[5].ToString(), 3, 100);

        allQuestions.Add(question0diff3);
        allQuestions.Add(question1diff3);
        allQuestions.Add(question2diff3);
    }

    public void UpdateCurrentAnswers(Question question, params object[] optionalParams)
    {
        switch (question.id)
        {
            case 100:
                question.UpdateCurrentAnswers(optionalParams[1].ToString());
                break;
            case 101:
                question.UpdateCurrentAnswers(optionalParams[2].ToString());
                break;
        }
    }
}
