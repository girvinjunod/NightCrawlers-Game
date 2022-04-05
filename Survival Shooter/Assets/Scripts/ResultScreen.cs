using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EndlessScoreboard;

    public GameObject WaveScoreboard;
    void Awake()
    {
        // PlayerPrefs.DeleteKey("EndlessScoreboard");
        //enable the scoreboard
        // StateHolder.GameMode = "WaveMode";

        if (StateHolder.GameMode == "WaveMode")
        {
            WaveScoreboard.SetActive(true);
        }
        else if (StateHolder.GameMode == "ZenMode")
        {
            EndlessScoreboard.SetActive(true);
        }
    }

    public void ExitToMainMenu()
    {
        StateHolder.highScorePos = -1;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        StateHolder.highScorePos = -1;
        StateHolder.isGameOver = false;
        SceneManager.LoadScene(StateHolder.GameMode);
    }

}
