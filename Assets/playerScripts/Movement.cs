using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //all public variables
    [SerializeField] Transform groundCheck;
    public float playerSpeed = 1.0f;
    public int jumpPower = 1;
    [SerializeField] bool grounded;
    [SerializeField] LayerMask groundLayer;
    public Transform jumpArrow;

    private Rigidbody2D RB;

    const float groundCheckRadius = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        RB = gameObject.GetComponent<Rigidbody2D>();
        grounded = false;
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
        float verticalInput = Input.GetAxis("Vertical");
        bool jump = Input.GetButton("Jump");


        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(movement  * playerSpeed * Time.deltaTime);

        if(jump && grounded)
        {
            float jumpPowerX = Mathf.Cos(jumpArrow.rotation.z + Mathf.PI / 2); // Calculates the amount of power in the X axis and offsets it 90 degrees clockwise
            float jumpPowerY = Mathf.Sin(jumpArrow.rotation.z + Mathf.PI / 2); // Calculates the amount of power in the Y axis and offsets it 90 degrees clockwise
            Debug.Log(jumpPowerX);
            RB.AddForce(new Vector2 (jumpPowerX, jumpPowerY) * jumpPower, ForceMode2D.Impulse);
        }
    }

}
