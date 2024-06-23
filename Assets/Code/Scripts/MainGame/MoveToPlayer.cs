using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveToPlayer : MonoBehaviour
{
    public float moveSpeed = 2f; // Constant move speed 
    public bool canMove = true; // Can move?
    private GameObject player;
    private Rigidbody2D rb;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // Calculate the direction towards the player.
        Vector2 directionToPlayer = ((Vector2)player.transform.position - rb.position);

        // Move the enemy towards the player with the constant speed.
        if (canMove)
            rb.velocity = directionToPlayer.normalized * moveSpeed;


    }
}
