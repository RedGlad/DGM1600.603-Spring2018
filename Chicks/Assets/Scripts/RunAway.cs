using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour {
	// public Rigidbody enemy;
	public float moveSpeed;
	public Transform target;
	public Transform chickenPen;
	public int points = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			Debug.Log("Player has entered chicken's trigger.");
			transform.LookAt(target);
			transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
		}
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Player") {
			//
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
