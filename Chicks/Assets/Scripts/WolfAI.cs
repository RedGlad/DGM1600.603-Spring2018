using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour {

	public float runSpeed;
	public float wanderSpeed;
	public int damage = 10;

	void Start() {
		int rnd = Random.Range(0,360);
		transform.Rotate(0,rnd,0);
	}
	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "Player") {
			transform.LookAt(other.gameObject.transform);
			Attack();
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
		//using random degree above, rotate wolf when it sees a wall and draw a ray
		if (Physics.Raycast(transform.position, fwd, out hit, 1.5f)) {
			if (hit.collider.tag == "Wall"){
				transform.Rotate(0,rnd,0);
				Debug.DrawRay(transform.position, fwd*1.5f, Color.red, 5);
			}
		}
	}
	void Attack() {
		// set ray direction to forward of the wolf
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		// face player and run at
		Debug.DrawRay(transform.position, fwd*1.5f, Color.green, 5);
		transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision other) {
		// damage player if touched by wolf
		if (other.gameObject.name == "Player") {
			var hit = other.gameObject;
			var health = hit.GetComponent<PlayerHealth>();
			other.gameObject.GetComponent<PlayerHealth>();
			if (health != null){
				health.TakeDamage(damage);
			}
		}
		if (other.gameObject.tag == "Bullet"){
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
