using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour {
	// public Rigidbody enemy;
	public float moveSpeed;
	Transform chickenPen;
	public int points = 10;
	// Use this for initialization
	void Start () {
		chickenPen = GameObject.FindGameObjectWithTag("Drop").transform;
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
		}
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Player") {
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
