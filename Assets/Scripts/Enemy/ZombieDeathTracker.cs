using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathTracker : MonoBehaviour
{
    public List<GameObject> aliveZombies = new List<GameObject>();
    public int prevSize;
    void Start()
    {
        prevSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
