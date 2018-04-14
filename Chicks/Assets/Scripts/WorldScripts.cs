using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScripts : MonoBehaviour {

	public float dayCycleSpeed;
	public Transform daylight;

	void Start () {
		// Probably put background music here?
	}
	void Update () {
		// Control daycycle
		daylight.transform.Rotate(dayCycleSpeed*Time.deltaTime,0,0);
	}
}
