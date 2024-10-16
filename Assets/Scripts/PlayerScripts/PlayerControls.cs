using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 1f;   
    Vector2 movementInput;
    Vector2 mousePos;
    Rigidbody2D rb;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal"); //grabs input
        movementInput.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //grabs mouse location
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime); //does the translation

        Vector2 lookDirection = mousePos - rb.position; //gets direction of mouse from player
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x) * Mathf.Rad2Deg - 90f; //gets the angle
        rb.rotation = angle;
    }
   
    
}
