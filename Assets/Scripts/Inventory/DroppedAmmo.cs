using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroppedAmmo : MonoBehaviour
{
    public AmmoType AmmoType;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //hit weapon hitbox
    {

        var player = collision.gameObject;
        var inventory = player.GetComponent<Inventory>();
        var ammo = inventory.returnAmmo();
        var match = ammo.Find(item => item.GetType() == AmmoType);
        match.SetAmount(match.GetAmount() + amount); //adds the corresponding amount
        Destroy(gameObject);
    }
}
