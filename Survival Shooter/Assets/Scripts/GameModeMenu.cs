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
        StateHolder.isGameOver = false;
        StateHolder.GameMode = "ZenMode";
        SceneManager.LoadScene("ZenMode");
    }

    public void playWave()
    {
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1f;
        StateHolder.isGameOver = false;
        StateHolder.GameMode = "WaveMode";
        SceneManager.LoadScene("WaveMode");
    }

}
