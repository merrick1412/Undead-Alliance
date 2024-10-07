using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firepoint; //where the bullets come out
    public GameObject bulletPrefab; //the bullet
    public float fireRate = 0.5f;//in seconds
    
    public float nextFireTime = 0f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >=
            nextFireTime)
        {
            nextFireTime = Time.time + fireRate; //calc when time to shoot again
            Shoot();
        }
    }
        
    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
        
     
}
