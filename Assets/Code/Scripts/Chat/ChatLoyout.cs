using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ChatManager;

public class ChatLoyout : MonoBehaviour
{
    public ChatManager chatManager;
    public GameObject questionPanelPrefab;
    public GameObject chatGridPanel;
    public List<Sprite> panelSprites;
    public void BuildQuestionGrid(string minigame, List<Question> questions)
    {
        foreach (Question question in questions)
        {
            GameObject chatGridElement = Instantiate(questionPanelPrefab, chatGridPanel.GetComponent<GridLayoutGroup>().transform);
            chatGridElement.GetComponent<Button>().onClick.AddListener(() => chatGridElement.GetComponent<QuestionPanel>().ShowAnswerPanel(minigame, question, questions));
            chatGridElement.GetComponent<QuestionPanel>().CreateQuestionPanel(question, panelSprites[question.difficulty-1]);
        }
    }

    public void DestroyQuestionGrid()
    {
        foreach (Transform child in chatGridPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
