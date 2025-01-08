using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowcontroller : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 playerPos = new Vector3 (player.transform.position.x, player.transform.position.y, 0);
        var angle = getAngleToMouse(player);
        float floatAngle = (float)angle;
        //float dAngle = floatAngle - transform.rotation.z;
        //transform.RotateAround(playerPos, Vector3.forward, dAngle * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, floatAngle);
       
    }

    double getAngleToMouse(GameObject gameObject)
    {
        double calc_angle = Math.Atan2(gameObject.transform.position.y - Input.mousePosition.y, gameObject.transform.position.x - Input.mousePosition.x);
        return calc_angle * (180 / Math.PI);
    }
}
