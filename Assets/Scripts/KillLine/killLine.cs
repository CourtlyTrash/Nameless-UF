using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killLine : MonoBehaviour
{

    public float MoveSpeedStart = 0.2f;
    public float MoveSpeedMax = 3.0f;
    private GameObject gameState;

    private void Start()
    {
        gameState = GameObject.Find("GameHandler");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(0,1);
        transform.Translate(Movement *  MoveSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameState.GetComponent<GameState>().ResetPlayer();
        }
    }
}
