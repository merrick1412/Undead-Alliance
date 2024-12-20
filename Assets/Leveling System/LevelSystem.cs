using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour{

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;
    public GameObject player;
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystem() {
        level = 0;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount) { 
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            // Enough experience to level up
            level++;
            experience -= experienceToNextLevel;            
            player.GetComponent<PlayerHealthController>().setMaxHealth(50);
            player.GetComponent<PlayerHealthController>().AddHealth(player.GetComponent<PlayerHealthController>().maxPlHealth);
            OnLevelChanged(this, EventArgs.Empty);
            //if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        return (float)experience / experienceToNextLevel;
    }
}
