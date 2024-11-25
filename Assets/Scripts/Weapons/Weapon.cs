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
    public int MagazineSize;
    
    public PlayerInventoryController playerInventoryController;

    void Start()
    {
        
    }

    

    void Update()
    {
       
      
    }

    public bool isAutomatic()
    {
        return Automatic;
    }

    
    

    public void CopyStats(Weapon other)
    {
        weaponName = other.weaponName;
        gunshotSound = other.gunshotSound;
        weaponType = other.weaponType;
        bulletForce = other.bulletForce;
        rateOfFire = other.rateOfFire;
        Automatic = other.Automatic;
        MagazineSize = other.MagazineSize;
        bulletPrefab = other.bulletPrefab;
        ammoType = other.ammoType;
        
    }


}
