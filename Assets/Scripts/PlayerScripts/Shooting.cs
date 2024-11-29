using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    private Inventory inventory;
    private Weapon currentWeapon;

    public float bulletForce = 20f;
    private float nextFireTime = 0f;

    // Use Start() to schedule the weapon initialization after a delay
    private void Start()
    {
        // Call InitializeWeapon after a small delay to ensure Inventory is set up
        Invoke("InitializeWeapon", 0.1f); // 0.1 seconds delay
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
        currentWeapon = inventory.GetCurrentWeapon();

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

    void Update()
    {
        // If currentWeapon or audioSource is null, return early
        if (currentWeapon == null || audioSource == null)
        {
            return;
        }

        // Handle shooting logic here
        if (currentWeapon.isAutomatic())
        {
            if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; // calculates when the gun can shoot again
                Shoot();
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
                nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; // calculates when the gun can shoot again
                Shoot();
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
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
