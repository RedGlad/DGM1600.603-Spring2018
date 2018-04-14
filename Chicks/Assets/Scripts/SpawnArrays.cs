using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrays : MonoBehaviour {

	// public GameObject[] spawnPoints;
	public GameObject chicken, wolf;
	public int chickenCount, wolfCount;
	public float spawnRangeSize, spawnHeight;

	void Start () {
		// spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));
		wolf = (GameObject)Resources.Load("Wolf", typeof(GameObject));
		Spawn();
	}

	void Spawn(){
		// Spawn chickens and wolves at random locations within range of script.
		// Originally used the array of spawnpoints, which is why the script is named SpawnArrays.
		// I decided I liked a completely random spawn system better.
		for (int i = 0; i < chickenCount; i++) {
			float rndX = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			float rndY = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			GameObject.Instantiate(chicken, new Vector3(rndX,spawnHeight,rndY), Quaternion.identity);
		}
		for (int i = 0; i < wolfCount; i++) {
			float rndX = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			float rndY = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			GameObject.Instantiate(wolf, new Vector3(rndX,spawnHeight,rndY), Quaternion.identity);
		}
		print(chickenCount + " chickens have been created.");
		print(wolfCount + " wolves have been created.");
	}
}
