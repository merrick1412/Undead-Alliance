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
    private Weapon currentWeapon; //active weapon
    public GameObject WeaponDropPrefab; //assigns the prefab for creating dropped weapons
    void Start()
    {
        EquipWeapon(sidearm);
    }
    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//these correspond to numbers on keybooard for weapon selection
        {
            EquipWeapon(primary);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(secondary);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(sidearm);
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

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon == null) //cant equip nothing
        {
            return;
        }
        if (currentWeapon != null)
        {
            currentWeapon.HideWeapon();
        }
        currentWeapon= weapon; //self explanatory
        if (currentWeapon!=null)
        {
            currentWeapon.ShowWeapon();
        }
        Debug.Log($"Equipped {weapon.weaponName}");

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
        else if (newWeapon.weaponType == WeaponType.Primary)
        {
            if (primary != null)
            {
                DropWeapon(primary);
            }
            primary= newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Secondary)
        {
            if (secondary != null)
            {
                DropWeapon(secondary);
            }
            secondary= newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Throwable)
        {
            if (throwable != null)
            {
                DropWeapon(throwable);
            }
            throwable= newWeapon;
        }
        else if (newWeapon.weaponType == WeaponType.Equipment)
        {
            if (equipment != null)
            {
                DropWeapon(equipment);
            }
            equipment= newWeapon;
        }

    }

    public void DropWeapon(Weapon weapon)
    {
        if (weapon == null) return;

        Vector3 dropPosition = transform.position + transform.forward;
        GameObject droppedItem = Instantiate(WeaponDropPrefab,dropPosition,Quaternion.identity); //created the dropped gun object

        Weapon droppedWeapon = droppedItem.GetComponent<Weapon>(); //gives the weapon script to the dropped item prefab 
        if (droppedWeapon != null)
        {
            droppedWeapon.CopyStats(weapon); //gives the dropped gun the same stats as the equipped version
        }

        if (weapon == sidearm) sidearm = null; //deletes the gun from inventory. yes i know this is bad code
        else if (weapon == primary) primary = null;
        else if (weapon == secondary) secondary = null;
        else if (weapon == throwable) throwable = null;
        else if (weapon == equipment) equipment = null;
        else if (weapon == special) special = null;
        if (currentWeapon == weapon) //makes sure its unequiped
        {
            currentWeapon = null;
        }

    }
}
