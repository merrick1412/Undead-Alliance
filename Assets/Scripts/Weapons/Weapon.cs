using System;
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
    public Int32 MagazineSize;
    public Int32 MagazineCount;
    public bool isShotgun = false;
    public float shotgunSpreadAngle;
    public Int32 shotgunPelletCount;
    public float reloadTime;
    public bool isReloading = false;
    public bool isSniper = false;
    
    public PlayerInventoryController playerInventoryController;

    void Start()
    {
        playerInventoryController= GetComponentInParent<PlayerInventoryController>();
    }

    

    void Update()
    {
       
      
    }

    public bool isAutomatic()
    {
        return Automatic;
    }

    public void Reload()
    {
        
        isReloading = true;
        StartCoroutine(ChangeBoolAfterDelay(reloadTime));               
    }
    private IEnumerator ChangeBoolAfterDelay(float seconds) //changes reloading to false after reload time
    {
        yield return new WaitForSeconds(seconds);
        if (MagazineSize > getRemainingBullets())
        {
            MagazineCount = getRemainingBullets();
            
        }
        if (MagazineSize < getRemainingBullets())
        {
            MagazineCount = MagazineSize;
        }       
        isReloading = false;
        Debug.Log("finished reload");
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
        MagazineCount = other.MagazineCount;
        isShotgun = other.isShotgun;
        shotgunSpreadAngle = other.shotgunSpreadAngle;
        shotgunPelletCount = other.shotgunPelletCount;
        reloadTime = other.reloadTime;
        isSniper = other.isSniper;
}

    private Int32 getRemainingBullets()
    {
        return playerInventoryController.AmmoBeingUsed();
    }
    public void useAmmo()
    {
        MagazineCount = MagazineCount - 1;
    }
    
}
