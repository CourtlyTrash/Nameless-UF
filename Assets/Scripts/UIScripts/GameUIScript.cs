using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIScript : MonoBehaviour
{
    private bool escape;
    GameState gameState;

    private void Start()
    {
        gameState = GameObject.Find("GameHandler").GetComponent<GameState>();
    }

    private void Update()
    {
        escape = Input.GetKeyDown(KeyCode.Escape);

        if (escape)
        {
            Debug.Log("esc pressed");

            gameState.gamePaused = true;
        }
    }

    void RestartGame()
    {

    }

    void SwitchToMainMenu()
    { 
        
    }

    void SwitchToNextLevel()
    {

    }
}
