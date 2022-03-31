using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // void Awake()
    // {
    //     Resolution[] resolutions = Screen.resolutions;

    //     // Print the resolutions
    //     foreach (var res in resolutions)
    //     {
    //         Debug.Log(res.width + "x" + res.height + " : " + res.refreshRate);
    //     }
    // }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();


    }
}
