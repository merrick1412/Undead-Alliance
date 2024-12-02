using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private PlayerControls player;

    private void Awake() {
        LevelSystem levelsystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelsystem);
        player.SetLevelSystem(levelsystem);
    }
}
