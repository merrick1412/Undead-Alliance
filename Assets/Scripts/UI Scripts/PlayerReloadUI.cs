using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerReloadUI : MonoBehaviour
{
    public Inventory inventory;
    private float reloadTime;
    public TextMeshProUGUI text;
    public GameObject UI;
    private bool isReloading = false;
    
    

    void Update()
    {
        
        if (inventory == null)
        {
            Debug.Log("problem here");
            inventory = GetComponent<Inventory>();
        }
        if (inventory.currentWeapon.isReloading && !isReloading)
        {
            Debug.Log("Started reload");

            isReloading = true;
            reloadTime = inventory.currentWeapon.reloadTime;
            text.gameObject.SetActive(true);
            StartCoroutine(ChangeBoolAfterDelay(reloadTime));

            //float passedTime = 0f;
           // while (passedTime < reloadTime)
            //{
           //     passedTime += Time.deltaTime;
           //     Debug.Log("running here");
           // }
           // text.gameObject.SetActive(false);
           // isReloading = false;
        }

        //Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
       // reloadBar.transform.position = screenPosition;
    }
    private IEnumerator ChangeBoolAfterDelay(float seconds) //changes reloading to false after reload time
    {
        yield return new WaitForSeconds(reloadTime);
        text.gameObject.SetActive(false);
        isReloading = false;
        Debug.Log("finished reload");
    }


}
