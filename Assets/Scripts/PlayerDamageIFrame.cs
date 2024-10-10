using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageIFrame : MonoBehaviour
{
    private IFrameController invincibleControl;
    [SerializeField]
    private float IFrameDuration;
    public void Awake()
    {
        invincibleControl = GetComponent<IFrameController>(); //accesses IFrame control
    }
    public void StartIFrame()
    {
        invincibleControl.StartIFrame(IFrameDuration);
    }
}
