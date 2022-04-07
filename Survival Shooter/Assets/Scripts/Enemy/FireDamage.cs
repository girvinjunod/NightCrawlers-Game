using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    int Damage = 5;
    bool playerInRange;
    float timeBetweenAttacks = 0.5f;
    float timer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && playerHealth.currentHealth > 0)
        {
            timer = 0f;
            playerHealth.TakeDamage(Damage);
        }

        if (playerHealth.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
