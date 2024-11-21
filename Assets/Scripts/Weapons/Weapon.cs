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
    public Inventory inventory;
    public PlayerInventoryController playerInventoryController;


    public void Start()
    {
        playerInventoryController = GetComponent<PlayerInventoryController>();
        inventory = transform.parent.GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogError("cant get inventory component");
        }
    }
    public void Update()
    {
        if (inventory == null)
        {
            inventory = transform.parent.GetComponent<Inventory>();
        }
        if (inventory.currentWeapon == this) 
        {

            Debug.Log($"current weapon is {GetComponentInParent<Inventory>().currentWeapon}");
            gameObject.SetActive(true);
        }
    }
    public bool isAutomatic()
    {
        return Automatic;       
    }
    
    
    public void HideWeapon()
    {
        gameObject.SetActive(false);
        Debug.Log($"Deactivating {this.name}");
    }
    public void ShowWeapon()
    {
        gameObject.SetActive(true);
        Debug.Log($"Activating {this.name}");
    }
    public void CopyStats(Weapon other) //copy function
    {
        weaponName = other.weaponName;
        gunshotSound = other.gunshotSound;
        weaponType= other.weaponType;
        bulletForce = other.bulletForce;
        rateOfFire = other.rateOfFire;
        Automatic = other.Automatic;
        MagazineSize = other.MagazineSize;
        bulletPrefab = other.bulletPrefab;
        ammoType= other.ammoType;
    }

    
}
