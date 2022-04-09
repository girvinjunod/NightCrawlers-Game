using UnityEngine;
using System.Collections.Generic;
public class PickupManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject powerPickup;
    public GameObject healthPickup;
    public GameObject speedPickup;
    public float spawnTime = 30f;
    public Transform[] spawnPoints;
    public static List<Vector3> usedSpawnPoints = new List<Vector3>();


    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        // int numOfTries = 10;
        // for (int i = 0; i < numOfTries; i++)
        // {
        if (!usedSpawnPoints.Contains(spawnPoints[spawnPointIndex].position)){                                  
            usedSpawnPoints.Add(spawnPoints[spawnPointIndex].position);
            // RANDOM ALGORITHM
            int random = Random.Range(0, 3);
            if (PowerManager.power >= 10){
                random = Random.Range(1,3);
                // HANDLE MAX POWER, DONT SPAWN POWER ORB
            }
            if (SpeedManager.speed >= 10){
                random = 2;
                // HANDLE MAX SPEED, DONT SPAWN SPEED ORB
            }
            if (random == 0){
                Instantiate(powerPickup, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else if (random == 1){
                Instantiate(speedPickup, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            else if (random == 2 ){
                Instantiate(healthPickup, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);            
            }
        }
        // }
    }
}
