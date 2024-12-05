using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAmmoController : MonoBehaviour
{
    public TextMeshProUGUI lightAmmoText;
    public TextMeshProUGUI mediumAmmoText;
    public TextMeshProUGUI heavyAmmoText;
    public TextMeshProUGUI grenadesAmmoText;
    private Inventory inventory;
    void Start()
    {
        inventory= GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory == null) return;

        UpdateAmmoUI(AmmoType.Light);
        UpdateAmmoUI(AmmoType.Medium);
        UpdateAmmoUI(AmmoType.Heavy);
        UpdateAmmoUI(AmmoType.Grenades);


    }
    private void UpdateAmmoUI(AmmoType ammoType)
    {
        Ammo ammo = inventory.returnAmmo().Find(ammo => ammo.GetType() == ammoType);

        switch (ammoType)
        {           

            case AmmoType.Light: lightAmmoText.text = "Light Ammo: " + ammo.GetAmount();
                break;
            case AmmoType.Medium:
                mediumAmmoText.text = "Medium Ammo: " + ammo.GetAmount();
                break;
            case AmmoType.Heavy:
               heavyAmmoText.text = "Heavy Ammo: " + ammo.GetAmount();
                break;
                case AmmoType.Grenades:
                grenadesAmmoText.text = "Grenades: " + ammo.GetAmount();
                break;           
        }
    }
}
