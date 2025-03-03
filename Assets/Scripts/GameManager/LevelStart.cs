using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    GameState gameState;
    private void Start()
    {
        gameState = GameObject.Find("GameHandler").GetComponent<GameState>();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameState.playerLeftStart = true;
        }
    }
}
