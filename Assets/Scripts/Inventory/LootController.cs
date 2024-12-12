using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    public List<GameObject> lootTable;
    public List<GameObject> weaponLootTableEarly;
    public List<GameObject> weaponLootTableMid;
    public List<GameObject> weaponLootTableLate;
    public float lootGate1;
    public float lootGate2;
    public float lootGate3;
    private int randomNum;
    public GameObject player;
    static System.Random rnd = new System.Random();
    void Start()
    {
    }

    private void randomWeaponDrop(Transform t)
    {
        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate1) //as player gets higher health, better loot odds
        {

            var droppedLoot = Instantiate(CreateDroppedWeapon(weaponLootTableEarly[GetRandomWeapon(weaponLootTableEarly)]), t.position, Quaternion.identity);

        }
        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate3 && (player.GetComponent<PlayerHealthController>().maxPlHealth > lootGate2)) ; //as player gets higher health, better loot odds
        {

            var droppedLoot = Instantiate(CreateDroppedWeapon(weaponLootTableMid[GetRandomWeapon(weaponLootTableMid)]), t.position, Quaternion.identity);

        }
        if (player.GetComponent<PlayerHealthController>().maxPlHealth > lootGate3)
        {
            var droppedLoot = Instantiate(CreateDroppedWeapon(weaponLootTableLate[GetRandomWeapon(weaponLootTableLate)]), t.position, Quaternion.identity);
        }

    }
    private void randomAmmoDrop(Transform t)
    {
        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate1) //as player gets higher health, better loot odds
        {
            var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), transform.position, Quaternion.identity);
            randomNum = GetRandomNum();
            droppedLoot.GetComponent<DroppedAmmo>().amount = 20 + (3 * randomNum);
        } //spawns in ammo with a random amount between 20 and 320

        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate2 && player.GetComponent<PlayerHealthController>().maxPlHealth > lootGate1)
        {
            randomNum = GetRandomNum();
            if (randomNum > 50)
            {
                randomNum = GetRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 10 + (2 * randomNum);
            } //50% get lots of light or some medium
            else
            {
                randomNum = GetRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), t.position, Quaternion.identity);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 75 + (3 * randomNum);
            }
        }

        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate3 && player.GetComponent<PlayerHealthController>().maxPlHealth > lootGate2)
        {
            randomNum = GetRandomNum();
            if (randomNum < 33)
            {
                randomNum = GetRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 50 + (3 * randomNum);
                var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), t.position, Quaternion.identity);
                droppedLoot1.GetComponent<DroppedAmmo>().amount = 200 + (4 * randomNum);
            }
            if (randomNum < 66 && randomNum > 33)
            {
                randomNum = GetRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 100 + (3 * randomNum);
                var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedHeavyAmmo"), t.position, Quaternion.identity);
                droppedLoot1.GetComponent<DroppedAmmo>().amount = 75 + (2 * randomNum);
            }
            else
            {
                randomNum = GetRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 200 + (3 * randomNum);
                var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedHeavyAmmo"), t.position, Quaternion.identity);
                droppedLoot1.GetComponent<DroppedAmmo>().amount = 75 + (3 * randomNum);
            }

        }
        else
        {
            randomNum = GetRandomNum();
            var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity);
            droppedLoot.GetComponent<DroppedAmmo>().amount = 200 + (4 * randomNum);
            var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedHeavyAmmo"), t.position, Quaternion.identity);
            droppedLoot1.GetComponent<DroppedAmmo>().amount = 200 + (3 * randomNum);
        }
    }
    public void LootRoll(Transform t)
    {
        var ran = GetRandomNum();
        if (ran > 90)
        {
            randomAmmoDrop(t);
        }
        ran = GetRandomNum();
        if (ran > 95)
        {
            randomWeaponDrop(t);
        }
    }

    private int GetRandomNum()
    {
        return Random.Range(1, 101);
    }
    private int GetRandomWeapon(List<GameObject> list)
    {
        int r = rnd.Next(list.Count);
        return r;
    }
    // Update is called once per frame
    private GameObject CreateDroppedWeapon(GameObject weapon)
    {
        

        Vector3 dropPosition = transform.position + transform.forward;
        GameObject droppedItem = FindObjectOfType<Inventory>().weaponDropPrefab;
        

        Weapon droppedWeapon = droppedItem.GetComponent<Weapon>();
        if (droppedWeapon != null)
        {
            droppedWeapon.CopyStats(weapon.GetComponent<Weapon>());
        }

        SpriteRenderer droppedSpriteRenderer = droppedItem.GetComponent<SpriteRenderer>();
        SpriteRenderer weaponSpriteRenderer = weapon.GetComponent<SpriteRenderer>();

        if (droppedSpriteRenderer != null && weaponSpriteRenderer != null)
        {
            droppedSpriteRenderer.sprite = weaponSpriteRenderer.sprite;
        }
        return droppedItem;
       
        
        Debug.Log($"Dropped {weapon.GetComponent<Weapon>().weaponName} at {dropPosition}");
    }
}
