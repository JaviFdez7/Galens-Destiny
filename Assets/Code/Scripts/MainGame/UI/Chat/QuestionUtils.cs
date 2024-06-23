using System.Collections.Generic;
using static ChatManager;

public static class QuestionUtils
{
    public static List<Question> GenerateRandomQuestions(List<Question> allQuestions, int countDifficulty1, int countDifficulty2, int countDifficulty3)
    {
        List<Question> result = new List<Question>();

        List<Question> difficulty1Questions = GetQuestionsByDifficulty(allQuestions, 1);
        List<Question> difficulty2Questions = GetQuestionsByDifficulty(allQuestions, 2);
        List<Question> difficulty3Questions = GetQuestionsByDifficulty(allQuestions, 3);

        result.AddRange(GetRandomQuestions(difficulty1Questions, countDifficulty1));
        result.AddRange(GetRandomQuestions(difficulty2Questions, countDifficulty2));
        result.AddRange(GetRandomQuestions(difficulty3Questions, countDifficulty3));

        return result;
    }

    private static List<Question> GetQuestionsByDifficulty(List<Question> allQuestions, int difficulty)
    {
        List<Question> questions = new List<Question>();
        foreach (Question question in allQuestions)
            if (question.difficulty == difficulty)
                questions.Add(question);
        return questions;
    }

    private static List<Question> GetRandomQuestions(List<Question> questions, int count)
    {
        List<Question> randomQuestions = new List<Question>();
        System.Random random = new System.Random();

        while(randomQuestions.Count < count)
        {
            int randomIndex;
            randomIndex = random.Next(questions.Count);
            if(!randomQuestions.Contains(questions[randomIndex]))
                randomQuestions.Add(questions[randomIndex]);
        }

        return randomQuestions;
    }
}