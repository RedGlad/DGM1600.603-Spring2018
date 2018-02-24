using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScripts : MonoBehaviour {

	public float dayCycleSpeed;
	public Transform daylight;
	// Use this for initialization
	void Start () {
		//probably put music here?
	}
	
	// Update is called once per frame
	void Update () {
		daylight.transform.Rotate(dayCycleSpeed*Time.deltaTime,0,0);
	}
}
