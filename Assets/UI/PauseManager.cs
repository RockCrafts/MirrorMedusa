using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public BoolVariable paused;
    public GameObject pauseMenu;
    private void Update()
    {
        if (paused.Value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        pauseMenu.SetActive(paused.Value);
    }
}
