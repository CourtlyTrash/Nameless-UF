using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    GameObject gameHandler;
    [SerializeField] Sprite activeCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("gameHandler");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = activeCheckpoint;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameHandler.GetComponent<GameState>().playerSpawn = transform;
        }
    }
}
