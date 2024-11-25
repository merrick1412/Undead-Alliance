using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Weapon sidearm;
    public Weapon primary;
    public Weapon secondary;
    public Weapon equipment;
    public Weapon throwable;
    public Weapon special;
    public Weapon currentWeapon; //active weapon
    public GameObject WeaponDropPrefab; //assigns the prefab for creating dropped weapons
    public PlayerInventoryController playerInventoryController; //interfaces between inventory and gameworld


    void Start()
    {
        PlayerInventoryController playerInventoryController = GetComponent<PlayerInventoryController>();
        EquipWeapon(primary);
    }
    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        HandleWeaponSwitch(); //split these up to remove clutter, they handle
        HandleWeaponPickup(); //keyboard input for inventory stuff

    }

    private void HandleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//these correspond to numbers on keybooard for weapon selection
        {
            EquipWeapon(primary);
            Debug.Log($"running key down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(secondary); Debug.Log($"running key down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(sidearm); Debug.Log($"running key down");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipWeapon(equipment);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            EquipWeapon(special);
        }
        if (Input.GetKeyDown(KeyCode.G)) //g for grenades
        {
            EquipWeapon(throwable);
        }
        if (Input.GetKeyDown(KeyCode.Backspace)) //backspace to drop gun
        {
            DropWeapon(currentWeapon);
        }
    }

    private void HandleWeaponPickup()
    {

    }
    public void EquipWeapon(Weapon weapon)
    {
        Debug.Log($"trying to equip {weapon.weaponName}");
        if (currentWeapon != null) //hides the currently equipped gun
        {
            HideWeapon(currentWeapon);
            Debug.Log($"hiding {currentWeapon.weaponName}");

        }

        currentWeapon = weapon; //self explanatory
        ShowWeapon(currentWeapon);

        Debug.Log($"Equipped {currentWeapon.weaponName}");

    }

    public void PickUpWeapon(Weapon newWeapon)
    {
        if (newWeapon.weaponType == WeaponType.Sidearm)
        {
            if (sidearm != null)
            {
                DropWeapon(sidearm); //drops if you already have one
            }
            sidearm = newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Primary && primary != null) //what this does is allows interchangablility between primary and secondary weapons
        {
            if (secondary == null)
            {
                newWeapon.weaponType = WeaponType.Secondary; //if secondary slot is empty, and picking up primary, converts weapon to secondary and equips
                secondary = newWeapon;
            }

        }
        else if (newWeapon.weaponType == WeaponType.Secondary && secondary != null)
        {
            if (primary == null)
            {
                newWeapon.weaponType = WeaponType.Primary;
                primary = newWeapon;
            }
        }
        else if (newWeapon.weaponType == WeaponType.Primary)
        {
            if (primary != null)
            {
                DropWeapon(primary);
            }
            primary = newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Secondary) //this code sucks but works
        {
            if (secondary != null)
            {
                DropWeapon(secondary);
            }
            secondary = newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Throwable)
        {
            if (throwable != null)
            {
                DropWeapon(throwable);
            }
            throwable = newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Equipment)
        {
            if (equipment != null)
            {
                DropWeapon(equipment);
            }
            equipment = newWeapon;
        }


    }

    public void DropWeapon(Weapon weapon)
    {
        if (weapon == null) return; //this makes sure the dropped weapon prefab gets all the components

        Vector3 dropPosition = transform.position + transform.forward;
        GameObject droppedItem = Instantiate(WeaponDropPrefab, dropPosition, Quaternion.identity);
        droppedItem.transform.SetParent(null);

        Weapon droppedWeapon = droppedItem.GetComponent<Weapon>();
        if (droppedWeapon != null)
        {
            droppedWeapon.CopyStats(weapon);
        }

        SpriteRenderer droppedSpriteRenderer = droppedItem.GetComponent<SpriteRenderer>();
        SpriteRenderer weaponSpriteRenderer = weapon.GetComponent<SpriteRenderer>();

        if (droppedSpriteRenderer != null && weaponSpriteRenderer != null)
        {
            droppedSpriteRenderer.sprite = weaponSpriteRenderer.sprite;
        }

        if (weapon == sidearm) sidearm = null;
        else if (weapon == primary) primary = null;
        else if (weapon == secondary) secondary = null;

        if (currentWeapon == weapon) currentWeapon = null;
        Destroy(weapon.gameObject);
        Debug.Log($"Dropped {weapon.weaponName} at {dropPosition}");


    }
    public void HideWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(false);
        Debug.Log($"Deactivating {weapon.weaponName}");
    }

    public void ShowWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);
        Debug.Log($"Activating {weapon.weaponName}");
    }
}
