using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour
{
    public List<GameObject> lootTable;
    public List<GameObject> weaponLootTable;
    public float lootGate1;
    public float lootGate2;
    public float lootGate3;
    private int randomNum;
    public GameObject player;
    void Start()
    {
        Object[] subListObjects = Resources.LoadAll("DroppedAmmo");
        foreach (Object subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;
            lootTable.Add(lo); //loads the ammo drop prefabs into the list
        }
        lootTable = new List<GameObject>();
        
    }

    public void randomWeaponDrop(Transform t)
    {
        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate1) //as player gets higher health, better loot odds
        {
            //var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), t.position, Quaternion.identity,t);
            
        } 
    }
    public void randomAmmoDrop(Transform t)
    {
        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate1) //as player gets higher health, better loot odds
        {
            var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), transform.position, Quaternion.identity);
            randomNum = getRandomNum();
            droppedLoot.GetComponent<DroppedAmmo>().amount = 20 + (3 * randomNum);
        } //spawns in ammo with a random amount between 20 and 320

        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate2 && player.GetComponent<PlayerHealthController>().maxPlHealth > lootGate1)
        {
            randomNum = getRandomNum();
            if (randomNum > 50)
            {
                randomNum = getRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity ,t);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 10 + (2 * randomNum);
            } //50% get lots of light or some medium
            else
            {
                randomNum = getRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), t.position, Quaternion.identity, t);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 75 + (3 * randomNum);
            }
        }

        if (player.GetComponent<PlayerHealthController>().maxPlHealth < lootGate3 && player.GetComponent<PlayerHealthController>().maxPlHealth > lootGate2)
        {
            randomNum = getRandomNum();
            if (randomNum < 33)
            {
                randomNum = getRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity, t);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 50 + (3 * randomNum);
                var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedLightAmmo"), t.position, Quaternion.identity, t);
                droppedLoot1.GetComponent<DroppedAmmo>().amount = 200 + (4 * randomNum);
            }
            if (randomNum < 66 && randomNum > 33)
            {
                randomNum = getRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity, t);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 100 + (3 * randomNum);
                var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedHeavyAmmo"), t.position, Quaternion.identity, t);
                droppedLoot1.GetComponent<DroppedAmmo>().amount = 75 + (2 * randomNum);
            }
            else
            {
                randomNum = getRandomNum();
                var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity, t);
                droppedLoot.GetComponent<DroppedAmmo>().amount = 200 + (3 * randomNum);
                var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedHeavyAmmo"), t.position, Quaternion.identity, t);
                droppedLoot1.GetComponent<DroppedAmmo>().amount = 75 + (3 * randomNum);
            }
            
        }
        else
        {
            randomNum = getRandomNum();
            var droppedLoot = Instantiate(lootTable.Find(item => item.name == "DroppedMediumAmmo"), t.position, Quaternion.identity,t);
            droppedLoot.GetComponent<DroppedAmmo>().amount = 200 + (4 * randomNum);
            var droppedLoot1 = Instantiate(lootTable.Find(item => item.name == "DroppedHeavyAmmo"), t.position, Quaternion.identity,t);
            droppedLoot1.GetComponent<DroppedAmmo>().amount = 200 + (3 * randomNum);
        }
    }

    public int getRandomNum()
    {
        return Random.Range(1, 101);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
