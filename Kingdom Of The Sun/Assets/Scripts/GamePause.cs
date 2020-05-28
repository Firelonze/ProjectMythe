using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    bool paused = false;
    GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (paused) 
            {
                Resume();
            }
            if (!paused) 
            {
                Pause();
            }
        }

    }

    void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
}
