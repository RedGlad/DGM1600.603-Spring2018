using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrays : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject chicken;
	public int chickenCount;

	void Start () {
		spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
		chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));
		Spawn();
	}

	void Spawn(){
		//spawn 3 chickens at random spawnpoints
		for (int i = 0; i < chickenCount; i++) {
			int spawn = Random.Range(0, spawnPoints.Length);
			GameObject.Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity);
			print("Chicken " + i + " has been created");
		}
	}
}
