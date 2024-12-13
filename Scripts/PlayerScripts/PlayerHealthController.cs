using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour 
{
    [SerializeField] //this allows health to be edited in unity editor
    public float maxPlHealth;
    [SerializeField]
    public float currentPlHealth;
    
    [SerializeField]
    private string mainMenuSceneName = "MainMenu"; // Add this to set the main menu scene name in Unity Editor
    
    public float healthPercent
    {
        get
        {
            return currentPlHealth / maxPlHealth;//grabs a percent of remaining hp
        }
    }
    
    public bool IFrame { get; set; }
    
    public UnityEvent OnDamaged;
    public UnityEvent OnDeath; // Added event for death
    
    public void TakeDamage(float damageAmnt)
    {
        if(currentPlHealth == 0) { //if health is already 0 dont do anything
            return;
        }
        if (IFrame) //gives a temporary invincibility after taking damage
        {
            return;
        }
        
        currentPlHealth -= damageAmnt;
        if (currentPlHealth <= 0)
        {
            currentPlHealth = 0; //if hp is negative fixes
            Die(); // Call the die method when health reaches 0
        }
        else
        {
            OnDamaged.Invoke(); //if taken damage without dying, IFrame activated
        }
    }
    
    private void Die()
    {
        OnDeath.Invoke(); // Trigger death event
        StartCoroutine(LoadMainMenuWithDelay());
    }
    
    private IEnumerator LoadMainMenuWithDelay()
    {
        yield return new WaitForSeconds(2f); // Add a small delay before loading main menu
        SceneManager.LoadScene(mainMenuSceneName);
    }
    
    public void AddHealth(float amountToAdd)
    {
        if (currentPlHealth == maxPlHealth) { //if health is already maxed
            return;
        }
        currentPlHealth += amountToAdd;
        if (currentPlHealth > maxPlHealth) { //adds health and accounts for overflow
            currentPlHealth = maxPlHealth;
        }
    }
    
    public bool IsAlive()
    {
        return currentPlHealth > 0;
    }
    
    public void setMaxHealth(float amountToAdd)
    {
        maxPlHealth = maxPlHealth + amountToAdd;
    }
}
