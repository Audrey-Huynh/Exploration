using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Final2");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }

}
