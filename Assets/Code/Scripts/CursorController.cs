using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{

    public Sprite cursorDefault;
    public Sprite cursorShoot;

    private Image imageComponent;

    public static CursorController instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        imageComponent = GetComponent<Image>();
        //If sceneName is Main Game set cursor to shoot. Else set to default
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Main Game")
        {
            SetCursorShoot();
        }
        else
        {
            SetCursorDefault();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Input.mousePosition;
        transform.position = cursorPos;
    }

    public void SetCursorShoot()
    {
        imageComponent.sprite = cursorShoot;
    }

    public void SetCursorDefault()
    {
        imageComponent.sprite = cursorDefault;
    }   

}
