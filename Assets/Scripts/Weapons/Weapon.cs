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

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        // Try to get the Inventory component from the parent
        
        if (inventory == null)
        {
            Debug.LogError("Can't get Inventory component");
        }
    }

    void OnEnable()
    {
        // Initialize when the weapon is enabled
        Initialize();
    }

    void Update()
    {
        // Make sure inventory is not null before accessing it
        if (inventory == null)
        {
            Debug.LogWarning("Inventory is null in Update, attempting to reinitialize");
            Initialize();
        }

        if (inventory != null && inventory.currentWeapon == this)
        {
            Debug.Log($"Current weapon is {GetComponentInParent<Inventory>().currentWeapon}");
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
        inventory= other.inventory;
    }


}
