using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTriggerScript : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		//teleport object backwards up a 15-degree slope, which is rise/run of 1/3.732.
		other.gameObject.transform.position += new Vector3(0,10,-37.32f);
	}
}
