using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerName : MonoBehaviour
{
    public TextMeshProUGUI playernameUI;

    public TextMeshProUGUI playernameMenu;
    private PlayerData playername;
    void Awake()
    {
        var savedData = PlayerPrefs.GetString("PlayerName", "Player");
        playername = new PlayerData(savedData);
        playernameUI.text = playername.playername;
    }

    private void OnDisable()
    {
        SaveName();
    }

    public void SaveName()
    {
        // Debug.Log(playernameUI.text);
        playernameMenu.text = playernameUI.text;
        PlayerPrefs.SetString("PlayerName", playernameUI.text);
    }
}
