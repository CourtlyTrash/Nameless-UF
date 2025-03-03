using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killLine : MonoBehaviour
{

    public float MoveSpeedStart = 0.2f;
    public float MoveSpeedMax = 3.0f;
    private GameState gameState;

    private void Start()
    {
        gameState = GameObject.Find("GameHandler").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameState.gameOver)
        {
            if (gameState.gamePaused == false && gameState.gameEnded == false && gameState.playerLeftStart)
            {
                Vector3 Movement = new Vector3(0,1);
                transform.Translate(Movement *  MoveSpeedStart * Time.deltaTime);
                
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            if (gameState.playerSpawn.position.y <= gameObject.transform.position.y + gameObject.transform.localScale.y/2 + 0.1)
            {
                
                gameState.gameOver = true;

            }
            if (gameState.gameOver)
            {
                
                gameState.destroyPlayer();
            }

            if (!gameState.gameOver)
            {
               
                gameState.ResetPlayer();
            }
        }

        
        

    }
}
