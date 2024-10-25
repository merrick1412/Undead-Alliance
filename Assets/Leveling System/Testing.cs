using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    private void Awake() {
        LevelSystem levelsystem = new LevelSystem();
        Debug.Log(levelsystem.GetLevelNumber());
        levelsystem.AddExperience(50);
        Debug.Log(levelsystem.GetLevelNumber());
        levelsystem.AddExperience(60);
        Debug.Log(levelsystem.GetLevelNumber());
    }
}
