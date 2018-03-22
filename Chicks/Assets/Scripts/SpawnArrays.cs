using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrays : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject chicken;
	public GameObject wolf;
	public int chickenCount;
	public int wolfCount;

	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));
		wolf = (GameObject)Resources.Load("Wolf", typeof(GameObject));
		Spawn();
	}

	void Spawn(){
		//spawn chickenCount amount of chickens at random spawnpoints
		for (int i = 0; i < chickenCount; i++) {
			int spawn = Random.Range(0, spawnPoints.Length);
			GameObject.Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity);
			print("Chicken " + i + " has been created.");
		}
		for (int i = 0; i < wolfCount; i++) {
			int spawn = Random.Range(0, spawnPoints.Length);
			GameObject.Instantiate(wolf, spawnPoints[spawn].transform.position, Quaternion.identity);
			print("Wolf" + i + " has been created.");
		}
	}
}
