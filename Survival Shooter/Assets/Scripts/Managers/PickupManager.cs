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
            int random = Random.Range(1, 3);
            if (random == 0 && PowerManager.power < 200){
                Instantiate(powerPickup, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            } else {
              random = Random.Range(1,2);
            }
            if (random == 1 && SpeedManager.speed < 10){
                Instantiate(speedPickup, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            } else {
              random = 2;
            }
            if (random == 2 ){
                Instantiate(healthPickup, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);            
            }
        }
        // }
    }
}
