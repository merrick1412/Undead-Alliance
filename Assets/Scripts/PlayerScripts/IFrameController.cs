using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class IFrameController : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealthController hControl;

    private void Awake()
    {
        hControl = GetComponent<PlayerHealthController>(); //dependency injection
    }

    public void StartIFrame(float iFrameDuration)
    {
        StartCoroutine(InvincibilityCoroutine(iFrameDuration));
    }
    private IEnumerator InvincibilityCoroutine(float IDuration) //allows multiple Iframes concurrently
    {
        hControl.IFrame = true;
        yield return new WaitForSeconds(IDuration); //once IFrame is over turns it off
        hControl.IFrame = false;
    }
}
