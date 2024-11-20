using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour //parent class for weapons
{
    public WeaponType weaponType;
    public AmmoType ammoType;
    public string weaponName;
    public AudioClip gunshotSound;
    public GameObject bulletPrefab;
    public float bulletForce;
    public float rateOfFire;
    public bool Automatic;
    public bool StarterWeapon = false;
    public int MagazineSize;
    public bool isAutomatic()
    {
        return Automatic;       
    }
    
    public void Start()
    {
        if (StarterWeapon)
        {              
            gameObject.SetActive(true);        
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void HideWeapon()
    {
        gameObject.SetActive(false);
    }
    public void ShowWeapon()
    {
        gameObject.SetActive(true);
    }
    public void CopyStats(Weapon other) //copy function
    {
        weaponName = other.weaponName;
        gunshotSound = other.gunshotSound;
        weaponType= other.weaponType;
        bulletForce = other.bulletForce;
        rateOfFire = other.rateOfFire;
        Automatic = other.Automatic;
        StarterWeapon = other.StarterWeapon;
        MagazineSize = other.MagazineSize;
        bulletPrefab = other.bulletPrefab;
        ammoType= other.ammoType;
    }

    
}
