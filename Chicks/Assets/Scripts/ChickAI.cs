using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAI : MonoBehaviour {

	public float runSpeed;
	public float wanderSpeed;
	Transform chickenPen;
	public int points = 10;

	void Start () {
		chickenPen = GameObject.FindGameObjectWithTag("Drop").transform;
		int rnd = Random.Range(0,360);
		transform.Rotate(0,rnd,0);
	}
	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			Run();
		}
		if (other.gameObject.name == "Ground") {
			Wander();
		}
	}
	void Wander() {
		int rnd = Random.Range(10,350);
		// set ray direction to forward of the chicken
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		// move chicken forward
		transform.Translate(Vector3.forward * wanderSpeed * Time.deltaTime);
		//using random degree above, rotate chicken when it sees a wall and draw a ray
		if (Physics.Raycast(transform.position, fwd, out hit, 1.5f)) {
			if (hit.collider.tag == "Wall"){
				transform.Rotate(0,rnd,0);
				Debug.DrawRay(transform.position, fwd*1.5f, Color.red, 5);
			}
		}
	}
	void Run() {
		// set ray direction to forward of the chicken
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		// face chicken away from player and run
		transform.Rotate(0,180,0);
		Debug.DrawRay(transform.position, fwd*1.5f, Color.green, 5);
		transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision other) {
		// teleport chicken to pen if touched by player
		if (other.gameObject.name == "Player") {
			transform.position = chickenPen.position;
			transform.rotation = chickenPen.rotation;
		}
	}
}
