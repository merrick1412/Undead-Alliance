using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; //needs more testing
    public Rigidbody2D rb;
    public int damage = 1;// damage can be multiplied by gun
    public GameObject impactEffect; //later can add blood/debris on impact
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Automatically assign the Rigidbody2D component
        rb.velocity = transform.up * speed;

        // Set bullet layer to appear on top of map, but below players and enemies
        gameObject.layer = 10;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>(); //makes sure bullet hit enemy
        if (enemy != null){
            enemy.TakeDamage(damage);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
