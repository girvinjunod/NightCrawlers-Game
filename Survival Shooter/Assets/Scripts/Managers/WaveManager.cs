using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WaveManager : MonoBehaviour
{
	int maxWave = 3;
	int currentWave = 0;
	List<GameObject> currentEnemy = new List<GameObject>();
	List<Wave> waves = new List<Wave>();

	public List<GameObject> enemy;
	public GameObject boss;
	public Transform[] spawnPoints;
	public PlayerHealth playerHealth;


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
	    for(int i = 0; i < maxWave; i++)
	    {
	        int weight;
	        List<GameObject> selectedEnemy = new List<GameObject>();
	        selectedEnemy.Add(enemy[i]);
	        weight = (i * 5) + 5;
	        if ( (i + 1) % 3 == 0)
	        {
	            selectedEnemy.Add(boss);
	        }
	        waves.Add(new Wave(weight, selectedEnemy, i + 1));
	    }
	}

	void Start()
	{
		InitWaves();
	}

	void Update()
	{
		RemoveDeadEnemy();
		if(currentWave != maxWave && waves.Count >= 0 && playerHealth.currentHealth > 0f && currentEnemy.Count == 0)
        {
			Spawn(waves[currentWave]);
        }
	}

	/**
	Enemy weight is its index + 1
	*/
	void Spawn(Wave wave)
    {
		List<GameObject> enemy = RandomizeEnemy(wave.enemyPool, wave.weight);

		foreach(GameObject enemyToSpawn in enemy)
		{
			var rnd = new Random();
			int spawnPointIndex = rnd.Next(0, spawnPoints.Length);
			GameObject enemyInstance = Instantiate(enemyToSpawn, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
			currentEnemy.Add(enemyInstance);
		}
		currentWave += 1;
	}

	List<GameObject> RandomizeEnemy(List<GameObject> enemyPool, int waveWeight)
    {
		var rnd = new Random();
		List<GameObject> randomEnemy = new List<GameObject>();

		int weight = 0;
		while (weight != waveWeight)
		{
			int idx = rnd.Next(0, enemyPool.Count);
			if ((weight + idx + 1) <= waveWeight)
			{
				weight += idx + 1;
				randomEnemy.Add(enemyPool[idx]);
			}
		}

		return randomEnemy;
	}

	void RemoveDeadEnemy()
    {
		foreach(GameObject enemy in currentEnemy.ToArray())
		{
			if(enemy == null)
			{
				currentEnemy.Remove(enemy);
			}
		}
    }
}
