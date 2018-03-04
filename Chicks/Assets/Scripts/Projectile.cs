using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int damage = 1;
	public int lifetime = 5;
	Transform cam;

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyProjectile());
		cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(cam.position);
	}
	IEnumerator DestroyProjectile(){
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}