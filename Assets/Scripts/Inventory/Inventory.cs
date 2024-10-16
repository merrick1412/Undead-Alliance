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
    void Start()
    {
        EquipWeapon(sidearm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipWeapon(Weapon weapon)
    {
        if (weapon == null) //cant equip nothing
        {
            return;
        }
        currentWeapon= weapon;
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

        //need to implement logic to drop guns
    }
}
