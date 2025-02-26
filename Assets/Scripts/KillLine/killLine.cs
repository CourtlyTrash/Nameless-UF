using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Vector3 Movement = new Vector3(0,1);
        transform.Translate(Movement *  MoveSpeedStart * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //To Do: if killline collides with the current spawn point then disable it, Make the kill line stop when game over.
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!gameState.gameOver)
            {
                gameState.ResetPlayer();

            }

            if (gameState.gameOver)
            {
                gameState.destroyPlayer();
            }

            if (gameState.playerSpawn.position.y < gameObject.transform.position.y + gameObject.transform.localScale.y/2 + 3)
            {
                Debug.Log("spawn under lava");
                gameState.gameOver = true;

            }
        }

        
    }
}
