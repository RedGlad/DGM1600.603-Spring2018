using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAI : MonoBehaviour {

	public float runSpeed;
	public float minWanderSpeed;
	public float maxWanderSpeed;
	Transform chickenPen;
	public int points = 1;
	public GameObject scoreManager;

	void Start () {
		//find chicken pen
		chickenPen = GameObject.FindGameObjectWithTag("Drop").transform;
		//turn a random direction before moving
		float rnd = Random.Range(0,360);
		transform.Rotate(0,rnd,0);
		scoreManager = GameObject.FindGameObjectWithTag("Score");
	}
	void OnTriggerStay(Collider other) {
		//choose movement based on situation
		if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			Run();
		}
		if (other.gameObject.name == "Ground") {
			Wander();
		}
	}
	void Wander() {
		float rnd = Random.Range(10,350);
		float rndSpeed = Random.Range(minWanderSpeed,maxWanderSpeed);
		// set ray direction to forward of the chicken
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		// move chicken forward using random speed chosen above
		transform.Translate(Vector3.forward * rndSpeed * Time.deltaTime);
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
			// scoreManager.AddPoints(points);
		}
	}
}
