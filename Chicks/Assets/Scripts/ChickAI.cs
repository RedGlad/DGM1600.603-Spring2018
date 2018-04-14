using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickAI : MonoBehaviour {

	public float runSpeed, minWanderSpeed, maxWanderSpeed, seeDistance;
	Transform chickenPen;
	public int points = 1;

	void Start () {
		// Find ChickenPen for teleportation
		chickenPen = GameObject.FindGameObjectWithTag("Drop").transform;
		// Point in a random direction when initialized
		transform.Rotate(0,Random.Range(0,360),0);
	}
	void Update () {
		// Bring glitched away objects back to playfield
		if (transform.position.y < 0.0f) {
			transform.SetPositionAndRotation(new Vector3(0,10,0), Quaternion.identity);
		}
	}
	void OnTriggerStay(Collider other) {
		// Run from Player
		if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			Run();
		}
		// Wander aimlessly
		if (other.gameObject.name == "Ground") {
			Wander();
		}
	}
	void Wander() {
		// Choose random speed to travel
		float rndSpeed = Random.Range(minWanderSpeed,maxWanderSpeed);
		transform.Translate(Vector3.forward * rndSpeed * Time.deltaTime);
		// Rotate a random degree when Raycast hits a wall or wolf
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		float rnd = Random.Range(10,350);
		if (Physics.Raycast(transform.position, fwd, out hit, seeDistance)) {
			if (hit.collider.tag == "Wall" || hit.collider.tag == "Wolf"){
				transform.Rotate(0,rnd,0);
				Debug.DrawRay(transform.position, fwd*seeDistance, Color.red, 5);
			}
		}
	}
	void Run() {
		// Run from player
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		transform.Rotate(0,180,0);
		Debug.DrawRay(transform.position, fwd*seeDistance, Color.green, 5);
		transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision other) {
		// Teleport to pen if caught by player, and send score to PlayerUIControl.AddPoints
		if (other.gameObject.name == "Player") {
			// Play sound and make particle effect here when added
			transform.position = chickenPen.position;
			var hit = other.gameObject;
			var health = hit.GetComponent<PlayerUIControl>();
			if (health != null)
				health.AddPoints(points);
		}
	}
}
