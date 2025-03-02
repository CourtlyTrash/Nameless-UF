using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Arrowcontroller : MonoBehaviour
{
    public Transform player;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameObject.Find("GameHandler").GetComponent<GameState>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - player.position.x, mousePos.y - player.position.y);
        
        if (gameState.gamePaused == false && gameState.gameEnded == false)
        {
            transform.up = direction;

        }
    }
}
