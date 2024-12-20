using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    public Inventory inventory;
    public Weapon currentWeapon;
    private float bulletForce;
    private PlayerInventoryController playerInventoryController;

    
    private float nextFireTime = 0f;

    // Use Start() to schedule the weapon initialization after a delay
    private void Start()
    {
        // Call InitializeWeapon after a small delay to ensure Inventory is set up
        Invoke("InitializeWeapon", 0.1f); // 0.1 seconds delay
        Invoke("InitializeInventoryController", 0.1f); // 0.1 seconds delay

    }
    // This method will run after the delay
    private void InitializeWeapon()
    {
        // Ensure inventory is properly initialized before accessing currentWeapon
        inventory = GetComponent<Inventory>();

        // Debug: Log to check if inventory is correctly initialized
        if (inventory == null)
        {
            Debug.LogError("Inventory is not initialized!");
            return;
        }

        // Try to get the current weapon after Inventory initialization
        currentWeapon = inventory.GetComponent<Weapon>();
        bulletPrefab = currentWeapon.bulletPrefab;
        

        // Log if weapon is successfully assigned or not
        if (currentWeapon == null)
        {
            Debug.LogError("currentWeapon is not set! Make sure the Inventory is properly initialized and has a weapon.");
        }
        else
        {
            Debug.Log("Current Weapon: " + currentWeapon.name);
        }

        // Check and assign the AudioSource from the current weapon
        if (currentWeapon != null)
        {
            audioSource = currentWeapon.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("No AudioSource found on the current weapon!");
            }
        }
    }
    private void InitializeInventoryController()
    {
        playerInventoryController = GetComponent<PlayerInventoryController>();
    }

    void Update()
    {
        // If currentWeapon is null, return early
        if (inventory.currentWeapon == null || inventory == null)
        {
            return;
        }
        if (currentWeapon != inventory.GetCurrentWeapon())
        {
            UpdateCurrentWeapon();
            Debug.Log("updating weapon");
        }
         //nested loops are a good programming practice
        Int32 remainingAmmo = playerInventoryController.AmmoBeingUsed();
        if (!currentWeapon.isReloading)
        {
            if (remainingAmmo > 0)
            {
                HandleShootingLogic();
            }
        }
    }
    private void UpdateCurrentWeapon()
    {
        currentWeapon = inventory.GetCurrentWeapon(); //if weapon is switched, changes gun properly
        bulletPrefab = currentWeapon.bulletPrefab;
        audioSource = currentWeapon.GetComponent<AudioSource>();
    }
    private void HandleShootingLogic()
    {
        // Handle shooting logic here
        if (currentWeapon.isAutomatic())
        {
            if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
            {
                if (currentWeapon.MagazineCount == 0)
                {
                    currentWeapon.Reload();
                    return;
                }
                nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; // calculates when the gun can shoot again
                if (currentWeapon.isShotgun) //does this if its a shotgun
                    ShootShotgun();
                else
                    Shoot();
                Int32 bulCount;
                if (currentWeapon.isShotgun) //shoots multiple if its a shotgun
                    bulCount = currentWeapon.shotgunPelletCount;
                else
                    bulCount = 1;
                UseAmmo(bulCount);
                
                if (!audioSource.isPlaying) // play sound when button is held for automatic
                {
                    audioSource.Play();
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                audioSource.Stop();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
            {
                if (currentWeapon.MagazineCount == 0)
                {
                    currentWeapon.Reload();
                    return;
                }
                nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; // calculates when the gun can shoot again
                if (currentWeapon.isShotgun) //does this if its a shotgun
                    ShootShotgun();
                else
                    Shoot();
                Int32 bulCount;
                if (currentWeapon.isShotgun) //shoots multiple if its a shotgun
                    bulCount = currentWeapon.shotgunPelletCount;
                else
                    bulCount = 1;
                UseAmmo(bulCount);
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // creates bullet
        if (!currentWeapon.Automatic)
        {
            audioSource.PlayOneShot(currentWeapon.gunshotSound); // plays gunshot sound if not automatic
        }
        bullet.layer = 10;        
        Destroy(bullet, 5.0f);
    }

    private void ShootShotgun()
    {
        Int32 shotgunPelletCount = currentWeapon.shotgunPelletCount;
        float spreadAngle = currentWeapon.shotgunSpreadAngle;

        Rigidbody2D playerRB = playerInventoryController.GetComponent<Rigidbody2D>();
        if (shotgunPelletCount > playerInventoryController.AmmoBeingUsed())
        {
            return; //if there isnt enough bullets to shoot all the pellets, returns
        }
        for (int i = 0; i < shotgunPelletCount; i++)
        {
            
            float angle = UnityEngine.Random.Range(-spreadAngle / 2, spreadAngle / 2);
            Quaternion rotation = Quaternion.Euler(0, 0, firePoint.eulerAngles.z + angle);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.layer = 10;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
           
            
            
            
        }

        if (!currentWeapon.Automatic)
        {
            audioSource.PlayOneShot(currentWeapon.gunshotSound);
        }
    }
    private void UseAmmo(Int32 amount)
    {
        playerInventoryController.GetAmmoBeingUsed().useAmmo(amount);
        currentWeapon.useAmmo();
    }
}
