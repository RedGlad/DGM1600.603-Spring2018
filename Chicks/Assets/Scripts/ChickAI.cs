using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAI : MonoBehaviour {

	public float moveSpeed;
	public float wanderSpeed;
	Transform chickenPen;
	public int points = 10;

	void Start () {
		chickenPen = GameObject.FindGameObjectWithTag("Drop").transform;
	}
	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			Run();
		}
		else {
			Wander();
		}
	}
	void Wander() {
		int rnd = Random.Range(30,330);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		transform.Translate(Vector3.forward * wanderSpeed * Time.deltaTime);

		if (Physics.Raycast(transform.position, fwd, 2)) {
			transform.Rotate(0,rnd,0);
			Debug.DrawRay(transform.position, fwd*2, Color.red, 100);
		}
	}
	void Run() {
		transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name == "Player") {
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
