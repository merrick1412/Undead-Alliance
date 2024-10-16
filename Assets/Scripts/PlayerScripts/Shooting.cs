using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip gunshotSound;
    private AudioSource audioSource;

    public float fireRate = 1f;//shots per second
    public float bulletForce = 20f;

    private float nextFireTime = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); //grabs gunshot
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; //calculates when gun can shoot again
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //creates bullet
        audioSource.PlayOneShot(audioSource.clip); //plays gunshot
        bullet.layer = LayerMask.NameToLayer("Bullets");//makes sure it gets assigned to the correct collision layer
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
