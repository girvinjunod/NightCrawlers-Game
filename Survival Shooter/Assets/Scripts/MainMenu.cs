using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI playername;
    void Awake()
    {
        // PlayerPrefs.DeleteKey("PlayerName");
        var savedName = PlayerPrefs.GetString("PlayerName", "Player");
        playername.text = savedName;
        // Debug.Log(savedName);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
