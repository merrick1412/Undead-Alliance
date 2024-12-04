using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private AmmoType type;
    private int amount;
    public AmmoType GetType() { return type; }
    public int GetAmount() { return amount; }
    public void SetAmount(int amount)
    {
        this.amount = amount;
    }
    public void SetType(AmmoType type)
    {
        this.type = type;
    }
    public void Initialize(AmmoType type, Int32 amount)
    {
        this.type = type;
        this.amount = amount;
    }
    

}
