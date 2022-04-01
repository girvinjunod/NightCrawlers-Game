using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenu : MonoBehaviour
{
    public void playEndless()
    {
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("ZenMode");
    }

    public void playWave()
    {
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_01");
    }

}
