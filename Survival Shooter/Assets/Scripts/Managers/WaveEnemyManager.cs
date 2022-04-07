using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveEnemyManager : MonoBehaviour
{
    Text text;
    int currentEnemy;

    public WaveManager waveManager;

    void Awake()
    {
        text = GetComponent<Text>();
    }


    void Update()
    {
        text.text = "Enemies: " + waveManager.currentEnemy.Count;
    }
}
