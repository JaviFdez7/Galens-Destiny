using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChatManager;

public interface IMinigameChat
{
    void InitializeQuestions(params object[] optionalParams);
    void SetupBinaryChat(params object[] optionalParams);
}

public class ChatManager : MonoBehaviour
{
    public bool activeChat = false;
    public  ChatLoyout chatLoyout; 

    public class Question
    {
        public string question { get; private set; }
        public string answer { get; private set; }
        public int difficulty { get; private set; }
        public int lostPoints { get; private set; }
        public bool covered { get; set; }


        public Question(string question, string answer, int difficulty, int lostPoints)
        {
            if(ValidateParameters(question, answer, difficulty, lostPoints))
            {
                this.question = question;
                this.answer = answer;
                this.difficulty = difficulty;
                this.lostPoints = lostPoints;
                covered = true;
            } else
                Debug.Log("Error validating Question creation");
        }

        private bool ValidateParameters(string question, string answer, int difficulty, int lostPoints)
        {
            bool validQuestion = question.Length<=110;
            bool validAnswer = answer.Length <= 110 ;
            bool validDifficulty = 1 <= difficulty && difficulty <= 3;
            bool validLostPoints = 0 <= lostPoints && lostPoints <= 1000;

            return validQuestion && validAnswer && validDifficulty && validLostPoints;
        }
    }

    public void InitializeChat(string minigame, List<Question> questions)
    {
        chatLoyout.DestroyQuestionGrid();
        chatLoyout.BuildQuestionGrid(minigame, questions);
    }    
}
