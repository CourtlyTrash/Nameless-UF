using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class levelEndSwitcher : MonoBehaviour
{

    GameState gameState;
    Scene currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("gameHandler").GetComponent<GameState>();
        currentLevel = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameState.gameEnded = true;
        }
    }
}
