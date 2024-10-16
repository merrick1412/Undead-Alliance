using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour //parent class for weapons
{
    public WeaponType weaponType;
    public string weaponName;
    public AudioClip gunshotSound;
    public GameObject bulletPrefab;
    public float bulletForce;
}
