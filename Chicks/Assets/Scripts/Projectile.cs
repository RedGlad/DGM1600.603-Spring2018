using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int lifetime;
	Transform cam;

	void Start () {
		//start countdown
		StartCoroutine(DestroyProjectile());
		//find camera
		cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	void Update () {
		//always face sprite toward camera
		transform.LookAt(cam.position);
	}
	void OnCollisionEnter(Collision other) {
		//destroy bullet if hitting walls or chickens
		if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Chicken") {
			Destroy(gameObject);
		}
		//destroy bullet and wolf if hitting wolf
		else if (other.gameObject.tag == "Wolf") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	IEnumerator DestroyProjectile(){
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}