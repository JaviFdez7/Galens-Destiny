using UnityEngine;

public class ChatAnimation : MonoBehaviour
{
    public Transform box;
    public GameObject dropdown;
    public GameObject dropup;


    public void OpenChat()
    {
        box.localPosition = new Vector2(0, -918);
        box.LeanMoveLocalY(0, 1f).setEaseOutExpo();
        dropup.SetActive(false);
        dropdown.SetActive(true);
        SoundBinaryManager.instance.PlayChatDragSound();
    }

    public void CloseChat()
    {
        box.LeanMoveLocalY(-918, 1f).setEaseOutExpo();
        dropup.SetActive(true);
        dropdown.SetActive(false);
        SoundBinaryManager.instance.PlayChatDragSound();
    }
    
    void Start()
    {
        dropup.SetActive(true);
        dropdown.SetActive(false);
    }
}