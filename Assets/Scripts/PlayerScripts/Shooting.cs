using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource audioSource;
    private Inventory inventory;
    private Weapon currentWeapon;

    public float bulletForce = 20f;

    private float nextFireTime = 0f;
    int magSize;
    int ammoCount;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        currentWeapon = inventory.GetCurrentWeapon();
        magSize = currentWeapon.MagazineSize;
        ammoCount = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = inventory.GetCurrentWeapon();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        if (currentWeapon.MagazineSize != magSize)
        {
            magSize = currentWeapon.MagazineSize; // Should add a Weapon ID, if 2 guns have the same mag size it won't register as a new gun with a new mag -- ASK Derek if questions
        }
        if (currentWeapon != null)
        {
            if (currentWeapon.isAutomatic())
            {
                if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
                {
                    if (ammoCount > 0)
                    {
                        nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; //calculates when gun can shoot again
                        Shoot();
                        --ammoCount;
                        if (!audioSource.isPlaying) //automatic weapons should play shooting when button is down then stop
                        {
                            audioSource.Play();
                        }
                    }
                    else
                    {
                        if (audioSource.isPlaying)
                        {
                            audioSource.Stop();
                        }
                        nextFireTime = Time.time + 1f * currentWeapon.rateOfFire; // calculates reload time
                        ammoCount = currentWeapon.MagazineSize; // "Reloads" gun
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
                    if (ammoCount == 0)
                    {
                        nextFireTime = Time.time + 1f / (currentWeapon.rateOfFire * 10); // calculates reload time
                        ammoCount = currentWeapon.MagazineSize; // "Reloads" gun
                    }
                    nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; //calculates when gun can shoot again
                    Shoot();
                    --ammoCount;
                }
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //creates bullet
        if (!currentWeapon.Automatic)
        {
            audioSource.PlayOneShot(currentWeapon.gunshotSound); //plays gunshot
        }
        bullet.layer = LayerMask.NameToLayer("Bullets");//makes sure it gets assigned to the correct collision layer
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
