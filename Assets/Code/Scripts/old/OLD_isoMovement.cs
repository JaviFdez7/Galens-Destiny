using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement2 : MonoBehaviour
{
    //Generated C# class from inputSystem
    private MappeableInput input = null;
    private Vector2 inputVector = Vector2.zero;
    private Rigidbody2D rb = null;
    [SerializeField]
    private float moveSpeed = 0.12f;
    private int lastVerticalDirection = -1;
    private int lastHorizontalDirection = 1;
    private Vector2 isometricMoveVector = new(2, 1);


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new MappeableInput();
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
        inputVector = value.ReadValue<Vector2>();
    }

    //To stop the player
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        inputVector = Vector2.zero;
    }

    //FixedUpdate because we use rigidBody
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * CartesianToISO());
    }

    private Vector2 CartesianToISO()
    {
        return new(inputVector.x, inputVector.y / 2);
    }
    private Vector2 IsometrizeInputVector()
    {
        if (inputVector == Vector2.zero) return inputVector;

        if (inputVector.x == 0) inputVector.x = lastHorizontalDirection;
        if (inputVector.y == 0) inputVector.y = lastVerticalDirection;
        lastHorizontalDirection = Math.Sign(inputVector.x);
        lastVerticalDirection = Math.Sign(inputVector.y);
        Debug.Log(inputVector);
        Vector2 result = new(isometricMoveVector.x * Math.Sign(inputVector.x), isometricMoveVector.y * Math.Sign(inputVector.y));

        return result;
    }
}
