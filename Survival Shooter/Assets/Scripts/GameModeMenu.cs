using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMenu : MonoBehaviour
{
    public void playEndless()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void playWave()
    {
        SceneManager.LoadScene("Level_01");
    }

}
