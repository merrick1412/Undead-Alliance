using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    private PlayerHealthController phc;
    private float hpPercent = 1;
    void Start()
    {
        healthBar.type = Image.Type.Filled;
        phc = FindObjectOfType<PlayerHealthController>();
        healthBar.fillAmount = hpPercent;
    }
    private void Update()
    {
        hpPercent = (phc.currentPlHealth / phc.maxPlHealth);
        healthBar.fillAmount = hpPercent;
    }
}
