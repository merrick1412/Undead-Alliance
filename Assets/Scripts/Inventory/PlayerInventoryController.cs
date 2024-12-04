using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public Inventory inventory;
    public bool WeaponNearby;
    private Weapon nearbyDroppedWeapon;
    GameObject newWeapon;
    private float fKeyHoldTime = 0f; //time the key has been held down
    private float requiredHoldTime = 3f; //checks that its been held down for 3 seconds
    
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (WeaponNearby && Input.GetKey(KeyCode.F))
        {
            if (Input.GetKey(KeyCode.F))
            {
                fKeyHoldTime += Time.deltaTime; //adds to hold time
                if (fKeyHoldTime >= requiredHoldTime)
                {
                    Debug.Log($"attempting to pickup {nearbyDroppedWeapon.weaponName}");
                    
                    inventory.PickUpWeapon(nearbyDroppedWeapon);
                    WeaponNearby = false;
                    Destroy(nearbyDroppedWeapon.gameObject);
                    nearbyDroppedWeapon = null;
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

    private void OnTriggerEnter2D(Collider2D collision) //hit weapon hitbox
    {
        
        newWeapon = collision.gameObject;
        nearbyDroppedWeapon = collision.gameObject.GetComponent<Weapon>();
        if (nearbyDroppedWeapon != null)
        {
            Debug.Log($"found weapon script"); //becomes true when in hitbox of verified weapon
            WeaponNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //leaving weapon hitbox
    {
        
        nearbyDroppedWeapon = null;
        WeaponNearby = false;
    }
    public Int32 AmmoBeingUsed()
    {
        AmmoType ammoType = inventory.currentWeapon.ammoType;
        List<Ammo> ammoList = inventory.returnAmmo();
        return ammoList.Find(ammo => ammo.GetType() == ammoType).GetAmount();
        /*
         * this finds the gun equipped, gets the type of ammo it uses, then returns how much of it you have
         */
    }
    // Update is called once per frame

}
