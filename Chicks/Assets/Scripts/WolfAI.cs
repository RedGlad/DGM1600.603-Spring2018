using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {

	public float runSpeed, minWanderSpeed, maxWanderSpeed, seeDistance;
	public int damage = 1;

	void Start() {
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
		// Avoid SafeZone
		if (other.gameObject.name == "SafeZone") {
			transform.LookAt(new Vector3(0,0,0));
			Wander();
		}
		// Chase Player
		else if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			Attack();
		}
		// Wander aimlessly
		else if (other.gameObject.name == "Ground") {
			Wander();
		}
	}
	void Wander() {
		// Choose random speed to travel
		float rndSpeed = Random.Range(minWanderSpeed,maxWanderSpeed);
		transform.Translate(Vector3.forward * rndSpeed * Time.deltaTime);
		// Rotate a random degree when Raycast hits a wall or chicken
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		float rnd = Random.Range(10,350);
		if (Physics.Raycast(transform.position, fwd, out hit, seeDistance)) {
			if (hit.collider.tag == "Wall" || hit.collider.tag == "Chicken"){
				transform.Rotate(0,rnd,0);
				Debug.DrawRay(transform.position, fwd*seeDistance, Color.red, 5);
			}
		}
	}
	void Attack() {
		// Chase player
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd*seeDistance, Color.green, 5);
		transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision other) {
		// Do damage when catching player, and send damage to PlayerUIControl.TakeDamage
		if (other.gameObject.name == "Player") {
			var health = other.gameObject.GetComponent<PlayerUIControl>();
			if (health != null) {
				// Play sound here when added
				health.TakeDamage(damage);
			}
		}
	}
}
