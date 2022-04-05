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
        StateHolder.GameMode = "ZenMode";
        SceneManager.LoadScene("Level_01");
    }

    public void playWave()
    {
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        StateHolder.GameMode = "WaveMode";
        SceneManager.LoadScene("Level_01");
    }

}
