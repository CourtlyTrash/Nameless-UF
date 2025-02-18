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
        if(collision.gameObject.CompareTag("Player"))
        {

            gameState.ResetPlayer();
            if (gameState.playerSpawn.position.y < gameObject.transform.position.y + gameObject.transform.localScale.y/2)
            {
                Debug.Log("spawn under lava");
                gameState.gameOver = true;
            }
        }

        
    }
}
