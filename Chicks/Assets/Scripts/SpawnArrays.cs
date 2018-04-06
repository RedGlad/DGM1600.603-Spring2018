using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrays : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject chicken;
	public GameObject wolf;
	public int chickenCount;
	public int wolfCount;
	public float spawnRangeSize;
	public float spawnHeight;

	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));
		wolf = (GameObject)Resources.Load("Wolf", typeof(GameObject));
		Spawn();
	}

	void Spawn(){
		//spawn chickenCount amount of chickens at random range in square around this script
		for (int i = 0; i < chickenCount; i++) {
			float rndX = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			float rndY = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			GameObject.Instantiate(chicken, new Vector3(rndX,spawnHeight,rndY), Quaternion.identity);
			print("Chicken " + i + " has been created.");
		}
		for (int i = 0; i < wolfCount; i++) {
			float rndX = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			float rndY = Random.Range(-spawnRangeSize/2,spawnRangeSize/2);
			GameObject.Instantiate(wolf, new Vector3(rndX,spawnHeight,rndY), Quaternion.identity);
			print("Wolf " + i + " has been created.");
		}
	}
}
