using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Movement : MonoBehaviour
{
    //all public variables
    [SerializeField]Transform groundCheck;
    [SerializeField]float playerSpeed = 1.0f;
    [SerializeField]int jumpPower = 1;
    [SerializeField]bool grounded;
    [SerializeField]LayerMask groundLayer;
    [SerializeField]Transform jumpArrow;
    

    int maxMoveVelocity = 2;
    int maxJumpVelocity = 5;
    private Rigidbody2D RB;
    private Animator animator;
    
    const float groundCheckRadius = 0.2f;
    GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        RB = gameObject.GetComponent<Rigidbody2D>();
        grounded = false;
        animator = GetComponent<Animator>();
        gameState = GameObject.Find("GameHandler").GetComponent<GameState>();
    }

    void GroundCheck()
    {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);

        if (colliders.Length > 0) 
        {
            grounded = true;    
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jump = Input.GetButton("Jump");


        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector2 movement = new Vector2(horizontalInput * playerSpeed, 0);
        if (grounded && RB.velocity.magnitude < maxMoveVelocity && gameState.gamePaused == false)
        {
            //transform.Translate(movement  * playerSpeed * Time.deltaTime);
            RB.AddForce(movement);
            
        }

        if(jump && grounded && gameState.gamePaused == false && gameState.gameEnded == false)
        {
            float jumpPowerX = Mathf.Cos(jumpArrow.rotation.eulerAngles.z * (Mathf.PI/180) + Mathf.PI/2); // Calculates the amount of power in the X axis and offsets it 90 degrees clockwise
            float jumpPowerY = Mathf.Sin(jumpArrow.rotation.eulerAngles.z * (Mathf.PI / 180) + Mathf.PI/2); // Calculates the amount of power in the Y axis and offsets it 90 degrees clockwise

            Vector2 jumpVector = new Vector2(jumpPowerX, jumpPowerY);

            if(RB.velocity.magnitude < maxJumpVelocity)
            {
                RB.AddForce(jumpVector * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

}
