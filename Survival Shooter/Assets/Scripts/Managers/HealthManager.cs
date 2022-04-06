using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public static int health;
    public static int maxHealth;
    Text text;
    // public GameObject GameOverCanvas;
    void Start()
    {
        text = GetComponent<Text>();
        health = 100;
        maxHealth = 100;
    }
    // Update is called once per frame
    void Update()
    {
        // text.text = health + "/" + maxHealth;      
        if (playerHealth.currentHealth <= 0)
        {
            // GameOverCanvas.SetActive(true);
            StateHolder.isGameOver = true;

        }
    }
}
