using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedWeapon : MonoBehaviour
{
    public WeaponType weaponType;
    public AmmoType ammoType;
    public string weaponName;
    public AudioClip gunshotSound;
    public GameObject bulletPrefab;
    public float bulletForce;
    public float rateOfFire;
    public bool Automatic;
    public bool canBeSecondary;
    public bool isAutomatic()
    {
        return Automatic;
    }
    
}
