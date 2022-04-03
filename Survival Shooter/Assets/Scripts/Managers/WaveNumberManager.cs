using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveNumberManager : MonoBehaviour
{
    Text text;
    int currentWave;

    public WaveManager waveManager;

    void Awake()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = "Wave "+ waveManager.currentWave;
    }
}
