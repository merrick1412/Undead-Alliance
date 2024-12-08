using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; //needs more testing
    public Rigidbody2D rb;
    public int damage = 1;// damage can be multiplied by gun
    public GameObject impactEffect; //later can add blood/debris on impact
    private int pierceCounter = 0;
    public int piercing;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Automatically assign the Rigidbody2D component
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Debug.Log("hit zombie");
            GameObject zombie = hitInfo.gameObject;
            zombie.GetComponent<ZombieHealth>().ZombieTakeDamage(damage);
            pierceCounter++;
            if (piercing == pierceCounter)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
