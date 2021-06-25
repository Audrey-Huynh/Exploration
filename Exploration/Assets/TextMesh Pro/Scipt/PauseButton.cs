using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    public void Pause()
    {
        
            if (PausePanel.active)
            {
                PausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                PausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        
    }
}
