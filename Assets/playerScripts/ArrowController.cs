using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrowcontroller : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {   
        float angle = getAngleToMouse(player);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    float getAngleToMouse(GameObject gameObject)
    {

        float MouseX = Input.mousePosition.x;
        float MouseY = Input.mousePosition.y;

        float objX = gameObject.transform.position.x;
        float objY = gameObject.transform.position.y;

        Vector2 Point_2 = new Vector2(MouseX, 100f);
        Vector2 Point_1 = new Vector2(objX, 0f);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x) * Mathf.Rad2Deg;

        return angle - 90;
    }
}
