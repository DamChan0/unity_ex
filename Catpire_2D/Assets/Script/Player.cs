using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D playerRigid;

    private Vector3 step;

    public Vector2 moveInput;
    private Vector3 moveDirection;
    private Transform playerTransform;
    private SpriteRenderer playerSprite;

    private Animator playerAnim;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void LateUpdate()           // LateUpdate is called after Update each frame
    {
        if (moveInput.x != 0)
        {
            playerSprite.flipX = moveInput.x < 0; // moceInput.x < 0 is true when the player is moving left
        }

        playerAnim.SetFloat("Speed", moveInput.magnitude);          // maganitude is the length of the vector

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        step.x = moveInput.x;
        print(step.x);

        step.y = moveInput.y;
        print(step.y);
    }


    private void move()
    {
        moveDirection = new Vector3(step.x, step.y, 0);                                   // Get the direction
        playerTransform.transform.position += moveDirection * speed * Time.deltaTime;   // Move the player
    }




}
