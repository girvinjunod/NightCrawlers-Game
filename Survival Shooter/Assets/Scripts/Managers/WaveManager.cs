using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class WaveManager : MonoBehaviour
{
    int maxWave = 10;
    List<Wave> waves = new List<Wave>();

    public List<GameObject> currentEnemy = new List<GameObject>();
    public List<GameObject> enemyType;
    public GameObject boss;
    public Transform[] spawnPoints;
    public PlayerHealth playerHealth;
    public int currentWave = 1;
    public GameObject reaper;

    static Random rnd = new Random();

    [System.Serializable]
    public class Wave
    {
        public int weight;
        public List<GameObject> enemyPool;
        public int waveNumber;

        public Wave(int weight, List<GameObject> enemyPool, int waveNumber)
        {
            this.weight = weight;
            this.enemyPool = enemyPool;
            this.waveNumber = waveNumber;
        }
    }

    void InitWaves()
    {
        for (int i = 0; i < maxWave; i++)
        {
            int weight = (i * 5) + 5;
            List<GameObject> spawnedEnemy = enemyType.GetRange(0, (i + 1) % enemyType.Count);
            waves.Add(new Wave(weight, spawnedEnemy, i + 1));
        }
    }

    void Start()
    {
        InitWaves();
    }

    void Update()
    {

        RemoveDeadEnemy();
        if (currentWave != maxWave && waves.Count >= 0 && playerHealth.currentHealth > 0f && currentEnemy.Count == 0)
        {
            StartCoroutine(Spawn(waves[currentWave]));
        }
    }

    /**
	Enemy weight is its index + 1
	*/
    IEnumerator Spawn(Wave wave)
    {
        currentWave += 1;
        List<GameObject> waveEnemy = RandomizeEnemy(wave);
        foreach (GameObject enemyToSpawn in waveEnemy.ToArray())
        {
            int spawnPointIndex = rnd.Next(0, 1000) % spawnPoints.Length;
            GameObject enemyInstance = Instantiate(enemyToSpawn, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            currentEnemy.Add(enemyInstance);
            yield return new WaitForSeconds(3);
        }
    }

    List<GameObject> RandomizeEnemy(Wave wave)
    {
        List<GameObject> randomEnemy = new List<GameObject>();

        int weight = 0;
        while (weight != wave.weight)
        {
            int idx = rnd.Next(0, 1000) % wave.enemyPool.Count;
            if ((weight + idx + 1) <= wave.weight)
            {
                weight += idx + 1;
                randomEnemy.Add(wave.enemyPool[idx]);
            }
        }

        // Add boss
        if (wave.waveNumber % 3 == 0)
        {
            for (int i = 0; i < wave.waveNumber / 3; i++)
            {
                randomEnemy.Add(boss);
            }
        }

        // Add Reaper
        if(wave.waveNumber == maxWave)
        {
            randomEnemy.Add(reaper);
        }

        return randomEnemy;
    }

    void RemoveDeadEnemy()
    {
        foreach (GameObject enemy in currentEnemy.ToArray())
        {
            if (enemy == null)
            {
                currentEnemy.Remove(enemy);
            }
        }
    }
    public int getNumWaves()
    {
        return currentWave;
    }
}
