using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float time = 0f;
    Text text;
    GameObject player;
    PlayerHealth playerHealth;

    public string timeString;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        text = GetComponent<Text>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHealth > 0)
        {
            time += 1 * Time.deltaTime;

            int minute = (int)time / 60;
            int seconds = (int)time % 60;

            timeString = Utils.getTimeFromSeconds((int)time);

            text.text = timeString;
        }
    }

    public string GetTimeString()
    {
        return timeString;
    }
}
