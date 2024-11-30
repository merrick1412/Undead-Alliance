using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weaponPrefabs;

    public GameObject GetWeaponByName(string weaponName)
    {
        foreach (GameObject weaponPrefab in weaponPrefabs)
        {
            Weapon weapon = weaponPrefab.GetComponent<Weapon>();
            if (weapon != null && weapon.weaponName == weaponName)
            {
                return weaponPrefab;
            }
        }

        return null;
    }
}
