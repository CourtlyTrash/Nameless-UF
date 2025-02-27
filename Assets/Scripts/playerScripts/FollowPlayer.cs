using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float movementFactor = 1f;
    Vector3 velocity = Vector3.zero;


    void FixedUpdate()
    {
        if (GameObject.Find("GameHandler").GetComponent<GameState>().currentPlayer != null)
        {
            if(target == null)
            {
                target = GameObject.Find("GameHandler").GetComponent<GameState>().currentPlayer.transform;
            }

            Vector3 targetPos = new Vector3(transform.position.x, target.position.y, -1);

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, movementFactor);   

        }
        
    }

}
