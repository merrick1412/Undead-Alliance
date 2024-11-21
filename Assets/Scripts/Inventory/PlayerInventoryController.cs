using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public Inventory inventory;
    public bool WeaponNearby;
    GameObject convertedWeapon;
    public Weapon convertedWeaponScript;
    private DroppedWeapon nearbyDroppedWeapon;
    GameObject newWeapon;
    private float fKeyHoldTime = 0f; //time the key has been held down
    private float requiredHoldTime = 3f; //checks that its been held down for 3 seconds
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (WeaponNearby && Input.GetKeyDown(KeyCode.F))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fKeyHoldTime += Time.deltaTime; //adds to hold time
                if (fKeyHoldTime >= requiredHoldTime)
                {
                    Debug.Log($"attempting to pickup {nearbyDroppedWeapon.weapon.weaponName}");
                    Weapon newWeapon = nearbyDroppedWeapon.GetComponent<Weapon>();
                    inventory.PickUpWeapon(newWeapon);
                    WeaponNearby = false;
                }
            }
            else
            {
                fKeyHoldTime = 0f; //if f is released reset the timer
            }
            
        }
    }
     public Inventory getInventory()
    {
        return inventory;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DroppedWeapon droppedWeapon = collision.GetComponent<DroppedWeapon>();
        if (droppedWeapon != null)
        {
            nearbyDroppedWeapon = droppedWeapon;
            WeaponNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DroppedWeapon droppedWeapon = collision.GetComponent<DroppedWeapon>();
        if (droppedWeapon != null && droppedWeapon == nearbyDroppedWeapon)
        {
            nearbyDroppedWeapon = null;
            WeaponNearby = false;
        }
    }

    // Update is called once per frame

}
