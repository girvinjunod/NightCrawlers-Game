using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerName : MonoBehaviour
{
    public TMP_InputField playernameUI;

    public TextMeshProUGUI playernameMenu;
    private PlayerData playername;
    void Awake()
    {
        var savedData = PlayerPrefs.GetString("PlayerName", "Player");
        // Debug.Log(savedData);
        playername = new PlayerData(savedData);
        // Debug.Log(playername.playername);
        playernameUI.text = playername.playername;
        // Debug.Log(playernameUI.text);
    }

    private void OnDisable()
    {
        SaveName();
    }

    public void SaveName()
    {
        // Debug.Log(playernameUI.text.Length - 1);
        if (playernameUI.text.Length - 1 > 0)
        {
            playernameMenu.text = playernameUI.text;
            PlayerPrefs.SetString("PlayerName", playernameUI.text);
        }
        else
        {
            // Debug.Log("Kosong");
            playernameMenu.text = "Player";
            PlayerPrefs.SetString("PlayerName", "Player");
        }
    }
}
