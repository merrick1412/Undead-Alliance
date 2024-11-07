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

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        audioSource = transform.Find("Weapon").GetComponentInChildren<AudioSource>(); //grabs gunshot from weapon
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = inventory.GetCurrentWeapon();

        if (currentWeapon != null)
        {

            if (currentWeapon.isAutomatic())
            {
                if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
                {
                    nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; //calculates when gun can shoot again
                    Shoot();
                    if (!audioSource.isPlaying) //automatic weapons should play shooting when button is down then stop
                    {
                        audioSource.Play();
                    }
                }
                if(Input.GetButtonUp("Fire1"))
                {
                    audioSource.Stop();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
                {
                    nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; //calculates when gun can shoot again
                    Shoot();
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
