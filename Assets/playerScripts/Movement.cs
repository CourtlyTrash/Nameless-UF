using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float playerSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool jump = Input.GetButton("Jump");

        Debug.Log(jump);

        Vector2 movement = new Vector2(horizontalInput, 0);
        transform.Translate(movement  * playerSpeed * Time.deltaTime);
    }
}
