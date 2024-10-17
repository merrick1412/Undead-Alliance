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
                if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
                {
                    nextFireTime = Time.time + 1f / currentWeapon.rateOfFire; //calculates when gun can shoot again
                    Shoot();
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
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
        audioSource.PlayOneShot(currentWeapon.gunshotSound); //plays gunshot
        bullet.layer = LayerMask.NameToLayer("Bullets");//makes sure it gets assigned to the correct collision layer
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
