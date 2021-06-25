using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameEnded = false;

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("Game Over");
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

}
