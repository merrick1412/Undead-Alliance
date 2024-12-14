using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("11_29_Main_Map");
    }

    public void Instructions()
    {
        SceneManager.LoadSceneAsync("InstructionsScene");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
