using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public float cursorDepth = 10f;  // Depth in front of the camera to keep the cursor in world space

    void Start()
    {
        // Hide the default cursor
        Cursor.visible = false;

        // If no camera is assigned, try to get the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Get the mouse position in screen space (in pixels)
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the screen position to world position at the desired depth
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, cursorDepth));

        // Set the position of the crosshair (this GameObject) to the mouse world position
        transform.position = mouseWorldPosition;

        // Optionally, reset rotation of the crosshair to prevent it from rotating
        transform.rotation = Quaternion.identity; // This keeps the crosshair upright
    }
}
