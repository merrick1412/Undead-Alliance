using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false; // Hide the default system cursor
    }

    void Update()
    {
        // Get the mouse position in screen space (pixels)
        Vector3 mousePosition = Input.mousePosition;

        // Convert the screen space mouse position to world space
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Ensure the crosshair stays at the same z-plane (2D) as the player
        mousePosition.z = 0;

        // Set the crosshair's position to follow the mouse
        transform.position = mousePosition;
    }
}
