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
    
    public float healthPercent
    {
        get
        {
            return currentPlHealth / maxPlHealth;//grabs a percent of remaining hp
        }
    }
    
    public bool IFrame { get; set; }
    
    public UnityEvent OnDamaged;
    
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
            SceneManager.LoadScene("Main Menu"); // Load main menu when health reaches zero
        }
        else
        {
            OnDamaged.Invoke(); //if taken damage without dying, IFrame activated
        }
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
    
    public void setMaxHealth(float amountToAdd)
    {
        maxPlHealth = maxPlHealth + amountToAdd;
    }
}
