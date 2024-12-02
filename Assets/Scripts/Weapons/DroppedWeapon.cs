using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    public Weapon weapon;

    private void Start()
    {

    }

    public void Initialize(Weapon weaponToDrop)
    {
        weapon.CopyStats(weaponToDrop); //when created, gives all the stuff to the dropped weapon
        GetComponent<SpriteRenderer>().sprite = weaponToDrop.GetComponent<SpriteRenderer>().sprite;
        GetComponent<AudioSource>().clip = weaponToDrop.GetComponent<AudioSource>().clip;
    }
}
