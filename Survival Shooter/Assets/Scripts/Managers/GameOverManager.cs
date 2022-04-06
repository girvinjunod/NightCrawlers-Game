using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class GameOverManager : MonoBehaviour
{

    // public float restartDelay = 5f;


    Animator anim;
    public Text timetext;

    public Text wave;

    public Text score;
    // float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // Debug.Log(StateHolder.isGameOver);
        if (StateHolder.isGameOver)
        {
            anim.SetTrigger("GameOver");
        }
        // Debug.Log("Game Over");


        // restartTimer += Time.deltaTime;

        // if (restartTimer >= restartDelay)
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
    }

    public void continueToResult()
    {
        // Debug.Log("Continue");
        // StateHolder.GameMode = "WaveMode";
        if (StateHolder.GameMode == "ZenMode")
        {
            StateHolder.playerTime = Utils.getSecondsFromTimeString(timetext.text);
            SceneManager.LoadScene("Result");
        }
        else if (StateHolder.GameMode == "WaveMode")
        {
            String[] arrwave = wave.text.Split(' ');
            String[] arrscore = score.text.Split(':');
            StateHolder.playerWave = int.Parse(arrwave[1]);
            StateHolder.playerScore = int.Parse(arrscore[1]);
            SceneManager.LoadScene("Result");
        }
        else
        {
            SceneManager.LoadScene("Result");
        }
    }

}