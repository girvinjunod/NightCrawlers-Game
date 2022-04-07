using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
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
