using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameState : MonoBehaviour
{
    public Transform playerSpawn;
    public GameObject player;
    public GameObject currentPlayer;

    public bool gameOver = false;
    public bool gamePaused = false;
    public bool gameEnded = false;
    public bool playerLeftStart = false;


    private Vector3 spawnPos;

    
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelEndScreen;
    [SerializeField] GameObject pauseScreen;


    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(playerSpawn.position.x, playerSpawn.position.y, playerSpawn.transform.position.z);
        currentPlayer = Instantiate(player, spawnPos, playerSpawn.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if (currentPlayer == null)
        {
            gameOver = true;
        }

        if (gamePaused && gameEnded == false)
        {
            pauseScreen.SetActive(true);
        }

        if (gamePaused == false)
        {
            pauseScreen.SetActive(false);
        }

        if (gameEnded)
        {
            levelEndScreen.SetActive(true);
        }
        
    }

    public void ResetPlayer()
    {
        //TO DO: Add a check to get if the current spawn point is diasabled by the killline.
        spawnPos = new Vector3(playerSpawn.position.x, playerSpawn.position.y, playerSpawn.transform.position.z);
        Destroy(currentPlayer);
        if (!gameOver)
        {
            currentPlayer = Instantiate(player, spawnPos, playerSpawn.rotation);
        }
 
        
        
    }

    public void destroyPlayer()
    {
        Destroy(currentPlayer);
    }
}
