using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerReloadUI : MonoBehaviour
{
    public Inventory inventory;
    public UnityEngine.UI.Image reloadBar;
    private float reloadTime;
    public GameObject player;
    private bool isReloading = false;
    
    void Start()
    {        
        reloadBar.gameObject.SetActive(false);
        
    }
    void Update()
    {
        if (inventory == null)
        {
            Debug.Log("problem here");
        }
        if (inventory.currentWeapon.isReloading && !isReloading)
        {
            StartCoroutine(Reload());
        }
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
        reloadBar.transform.position = screenPosition;
    }
    private IEnumerator Reload()
    {
        isReloading = true;
        reloadTime = inventory.currentWeapon.reloadTime;
        reloadBar.gameObject.SetActive(true);
        reloadBar.fillAmount = 1;
        float passedTime = 0f;
        while (passedTime < reloadTime)
        {
            passedTime += Time.deltaTime;
            reloadBar.fillAmount = 1 - (passedTime / reloadTime); //bar is filled as a percentage of reload time
            yield return null;
        }
        reloadBar.gameObject.SetActive(false);
        isReloading = false;
    }

}
