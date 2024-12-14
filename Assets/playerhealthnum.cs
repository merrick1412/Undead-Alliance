using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerhealthnum : MonoBehaviour
{
    PlayerHealthController phc;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        phc = FindObjectOfType<PlayerHealthController>();
        text.text =  $"$HP: {phc.currentPlHealth.ToString()}";
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = phc.currentPlHealth.ToString();
    }
}
