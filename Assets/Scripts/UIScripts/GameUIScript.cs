using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (gameState.gamePaused == false)
            {
                gameState.gamePaused = true;
            }

            else if (gameState.gamePaused == true)
            { 
                gameState.gamePaused = false;
            }
            
        }
    }

    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene != null) 
        { 
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void SwitchToMainMenu()
    {
        string mainMenuPath = SceneUtility.GetScenePathByBuildIndex(0);
        string mainMenu = mainMenuPath.Split("/")[2];
        SceneManager.LoadScene(mainMenu.Split(".")[0]);
        Debug.Log(mainMenu);
    }

    public void SwitchToNextLevel()
    {
        SceneUtility.GetBuildIndexByScenePath(SceneManager.GetActiveScene().path);
    }
}
