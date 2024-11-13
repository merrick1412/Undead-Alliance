using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    private Inventory inventory;
    public bool WeaponNearby;
    public Weapon convertedWeapon;
    private DroppedWeapon nearbyDroppedWeapon;
    GameObject newWeapon;
    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DroppedWeapon droppedWeapon = collision.GetComponent<DroppedWeapon>(); //if touching a dropped weapon
        if (droppedWeapon != null)
        {
            nearbyDroppedWeapon = droppedWeapon;
            ConvertNearbyWeapon(nearbyDroppedWeapon); //player is near a weapon, converts dropped weapon into a weapon
            WeaponNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DroppedWeapon droppedWeapon = collision.GetComponent<DroppedWeapon>();
        if (droppedWeapon != null && droppedWeapon == nearbyDroppedWeapon)
        {
            nearbyDroppedWeapon = null; //player moved away from weapon
        }
    }

    public GameObject ConvertNearbyWeapon(DroppedWeapon drop)
    {
       
        newWeapon.AddComponent<Weapon>();
        newWeapon.AddComponent<SpriteRenderer>(); //creates game object with the correct scripts
        newWeapon.GetComponent<Weapon>().CopyStats(drop.GetComponent<Weapon>()); //copies the stats
        return Instantiate(newWeapon,inventory.GetCurrentWeapon().transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    
}
