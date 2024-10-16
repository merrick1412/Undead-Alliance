using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false; //hides default mouse
    }

    void Update()
    {
        UnityEngine.Vector3 mousePosition = Input.mousePosition;//establishes the mouses location

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //gets the mouse locatoin in relation to the gaem world

        transform.position = new UnityEngine.Vector3(mousePosition.x,mousePosition.y, 0);
    }
}
