using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverManager : MonoBehaviour
{

    // public float restartDelay = 5f;


    Animator anim;
    public Text timetext;
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
        Debug.Log("Continue");
        StateHolder.playerTime = Utils.getSecondsFromTimeString(timetext.text);
        StateHolder.GameMode = "ZenMode";
        SceneManager.LoadScene("Result");
    }

}