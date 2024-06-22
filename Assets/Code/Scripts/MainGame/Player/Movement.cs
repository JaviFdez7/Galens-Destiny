using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //Generated C# class from inputSystem
    private MappeableInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Vector2 mousePosition;
    private Rigidbody2D rb = null;
    [SerializeField]
    private float moveSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new MappeableInput();

    }

    public void Start()
    {
        this.transform.position = PlayerData.instance.lastCheckPoint;
        print("Player spawned at: " + PlayerData.instance.lastCheckPoint);
    }

    private void OnEnable()
    {
        input.InGame.Movement.Enable();
        //Subscribe
        input.InGame.Movement.performed += OnMovementPerformed;
        input.InGame.Movement.canceled += OnMovementCanceled;


    }

    private void OnDisable()
    {
        input.Disable();
        //Unsubscribe
        input.InGame.Movement.performed -= OnMovementPerformed;
        input.InGame.Movement.canceled -= OnMovementCanceled;

    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    //To stop the player
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    //FixedUpdate because we use rigidBody
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
