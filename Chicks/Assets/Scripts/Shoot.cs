using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform target;
	public int shootSpeed;
	public int currentAmmo;
	public Text ammo;
	
	// Update is called once per frame
	void Update () {
		ammo.text = currentAmmo.ToString();
		if (Input.GetButtonDown("Fire1"))
		{
			if (currentAmmo >= 1) {
				Rigidbody clone;
				clone = (Rigidbody)Instantiate(projectile, target.position, target.rotation);
				clone.velocity = target.TransformDirection (Vector3.forward*shootSpeed*Time.deltaTime);
				currentAmmo --;
			}
			else {
				print("Out of ammo!");
			}
		}
	}
}
