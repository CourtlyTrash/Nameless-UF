using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Movement : MonoBehaviour
{
    //all public variables
    [SerializeField]Transform groundCheck;
    [SerializeField]float playerSpeed = 1f;
    [SerializeField]int jumpPower = 1;
    [SerializeField]bool grounded;
    [SerializeField]LayerMask groundLayer;
    [SerializeField]Transform jumpArrow;
    [SerializeField]float jumpShakeMagnitude = .4f;
    [SerializeField]float jumpShakeduration = .3f;
    [SerializeField]float jumpShakeDampingSpeed = .1f;
    [SerializeField] Sprite hammerSmash;
    

    int maxMoveVelocity = 2;
    int maxJumpVelocity = 5;
    private Rigidbody2D RB;
    private Animator animator;
    bool flipped = false;

    const float groundCheckRadius = 0.35f;
    GameState gameState;
    ScreenShake screenShake;
    SpriteRenderer sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        RB = gameObject.GetComponent<Rigidbody2D>();
        grounded = false;
        animator = GetComponent<Animator>();
        gameState = GameObject.Find("GameHandler").GetComponent<GameState>();
        screenShake = GameObject.Find("Main Camera").GetComponent<ScreenShake>();
        sprite = GetComponent<SpriteRenderer>();
        
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

    void JumpAnimationDone()
    {
        animator.SetBool("Jumped", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GroundCheck();
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jump = Input.GetButton("Jump") || Input.GetMouseButton(0);

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        
        Vector2 movement = new Vector2(horizontalInput * playerSpeed, 0);

        if(jump && grounded && gameState.gamePaused == false && gameState.gameEnded == false)
        {

            screenShake.StartscreenShake(jumpShakeduration, jumpShakeMagnitude, jumpShakeDampingSpeed);
            

            float jumpPowerX = -Mathf.Cos(jumpArrow.rotation.eulerAngles.z * (Mathf.PI/180) + Mathf.PI/2); // Calculates the amount of power in the X axis and offsets it 90 degrees clockwise
            float jumpPowerY = -Mathf.Sin(jumpArrow.rotation.eulerAngles.z * (Mathf.PI / 180) + Mathf.PI/2); // Calculates the amount of power in the Y axis and offsets it 90 degrees clockwise

            Vector2 jumpVector = new Vector2(jumpPowerX, jumpPowerY);

            if(RB.velocity.magnitude < maxJumpVelocity)
            {
                animator.SetBool("Jumped", true);
                RB.AddForce(jumpVector * jumpPower, ForceMode2D.Impulse);
                
            }

            
        }



        if (grounded && RB.velocity.x < maxMoveVelocity && gameState.gamePaused == false)
        {
            transform.Translate(movement * Time.deltaTime);
            //RB.AddForce(movement, ForceMode2D.Impulse);
            //RB.velocity.Set(Math.Clamp(movement.x, maxMoveVelocity, -maxMoveVelocity), RB.velocity.y);
        }
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0 && !flipped)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            flipped = !flipped;
        }

        else if (horizontalInput > 0 && flipped)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            flipped = !flipped;
        }

    }

}
