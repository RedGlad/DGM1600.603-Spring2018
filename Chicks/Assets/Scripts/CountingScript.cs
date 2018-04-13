using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingScript : MonoBehaviour {

	int chickenCountB;
	int chickenGot;
	public GameObject spawner;
	// Use this for initialization
	void Start () {
		chickenCountB = spawner.GetComponent<SpawnArrays>().chickenCount;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Chicken") {
			chickenGot ++;
			print(chickenGot + "/" + chickenCountB + " chickens caught!");
		}
	}
}
