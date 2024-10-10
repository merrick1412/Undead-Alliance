using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync("OptionsScene");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
