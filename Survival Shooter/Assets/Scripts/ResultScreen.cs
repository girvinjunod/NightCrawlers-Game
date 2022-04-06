using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ResultScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EndlessScoreboard;

    public GameObject WaveScoreboard;

    public TextMeshProUGUI text1;

    public TextMeshProUGUI text2;

    // public GameObject textBox;
    void Awake()
    {
        // PlayerPrefs.DeleteKey("EndlessScoreboard");
        //enable the scoreboard
        // StateHolder.GameMode = "ZenMode";

        if (StateHolder.GameMode == "WaveMode")
        {
            text1.text = "Score: " + StateHolder.playerScore;
            text2.text = "Wave: " + StateHolder.playerWave;
            text1.enabled = true;
            text2.enabled = true;
            // textBox.SetActive(true);
            WaveScoreboard.SetActive(true);
        }
        else if (StateHolder.GameMode == "ZenMode")
        {
            text2.text = "Time: " + Utils.getTimeFromSeconds(StateHolder.playerTime);
            text2.enabled = true;
            // textBox.SetActive(true);
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
