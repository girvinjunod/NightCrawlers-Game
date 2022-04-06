using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    // public GameObject GameOverCanvas;

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            // GameOverCanvas.SetActive(true);
            StateHolder.isGameOver = true;

        }
    }
}
