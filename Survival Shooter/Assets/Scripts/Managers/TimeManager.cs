using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float time = 0f;

    Text text;

    void Awake()
    {
        text = GetComponent <Text> ();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += 1 * Time.deltaTime;

        int minute = (int)time / 60;
        int seconds = (int)time % 60;
        text.text = minute.ToString() + ":" + seconds.ToString();
    }
}
