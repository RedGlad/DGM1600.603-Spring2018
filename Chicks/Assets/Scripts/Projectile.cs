using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int damage = 1;
	public int lifetime = 5;
	public Camera cam;

	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyProjectile());
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(cam.transform.position);
	}
	IEnumerator DestroyProjectile(){
		yield return new WaitForSeconds(lifetime);
		Destroy(gameObject);
	}
}