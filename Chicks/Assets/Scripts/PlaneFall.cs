using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFall : MonoBehaviour {

	public float fallSpeed;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,-fallSpeed*Time.deltaTime,0);
	}
}
