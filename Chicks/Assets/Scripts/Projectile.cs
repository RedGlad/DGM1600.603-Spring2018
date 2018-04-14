using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int lifetime;
	Transform cam;

	void Start () {
		// Start lifetime countdown
		StartCoroutine(DestroyProjectile());
		// Find camera to track
		cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	void Update () {
		// Track camera so sprite always faces viewer
		transform.LookAt(cam.position);
	}
	void OnCollisionEnter(Collision other) {
		// Destroy only the bullet if hitting walls or chickens
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Chicken") {
			Destroy(gameObject);
		}
		// Destroy the bullet AND wolf if hitting wolf
		else if (other.gameObject.tag == "Wolf") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	IEnumerator DestroyProjectile(){
		// After set liftime, destroy bullet
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}