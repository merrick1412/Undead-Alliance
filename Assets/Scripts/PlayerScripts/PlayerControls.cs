using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.Utils;
using HealthBarUi;

public class PlayerControls : MonoBehaviour {
    public float moveSpeed = 1f;
    Vector2 movementInput;
    Vector2 mousePos;
    Rigidbody2D rb;
    public Camera cam;

    private Material material;
    private Color materialTintColor;
    private LevelSystem levelSystem;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal"); //grabs input
        movementInput.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //grabs mouse location
        cam.transform.rotation = Quaternion.identity;
    }

    public void SetLevelSystem(LevelSystem levelSystem) {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e) {
        Flash(new Color(1, 1, 1, 1));

        // Also add way to increase health and / or increase health bar size.
    }

    /*
    private void SpawnParticleEffect() {
        Transform effect = Instantiate(pfEffect, transform);
        FunctionTimer.Create(() => Destroy(effect.gameObject), 3f);
    }*/

    private void Flash(Color flashColor) {
        materialTintColor = flashColor;
        material.SetColor("_Tint", materialTintColor);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime); //does the translation

        Vector2 lookDirection = mousePos - rb.position; //gets direction of mouse from player
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; //gets the angle
        rb.rotation = angle;
        cam.transform.rotation = Quaternion.identity;
        
    }


}
