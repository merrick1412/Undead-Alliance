using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [SerializeField] private LevelWindow levelWindow;

    private void Awake() {
        LevelSystem levelsystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelsystem);
    }
}
