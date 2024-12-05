using CodeMonkey;
using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSystemAnimated {

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private LevelSystem levelSystem;
    private bool isAnimating;

    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystemAnimated(LevelSystem levelSystem) {
        SetLevelSystem(levelSystem);

        FunctionUpdater.Create(() => Update());
    }

    public void SetLevelSystem(LevelSystem levelSystem) {
        this.levelSystem = levelSystem;

        level = levelSystem.GetLevelNumber();
        experience = levelSystem.GetExperience();
        experienceToNextLevel = levelSystem.GetExperienceToNextLevel();

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e) {
        isAnimating = true;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e) {
        isAnimating = true;
    }

    private void Update() {
        if (isAnimating) {
            if (level < levelSystem.GetLevelNumber()) {
                // Local level under the target level
                AddExperience();
            } else {
                // Local level equals the target level
                if (experience < levelSystem.GetExperience()) {
                    AddExperience();
                } else {
                    isAnimating = false;
                }
            }
        }
        Debug.Log(level + " " + experience);
    }

    private void AddExperience() {
        experience++;
        if (experience >= experienceToNextLevel) {
            level++;
            experience = 0;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber() {
        return level;
    }

    public float GetExperienceNormalized() {
        return (float)experience / experienceToNextLevel;
    }


}
