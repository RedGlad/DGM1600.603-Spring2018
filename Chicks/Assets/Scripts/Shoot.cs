using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform target;
	public int shootSpeed, ammo;
	public Text ammoText;
	
	void Update () {
		// Update UI
		ammoText.text = ammo.ToString();

		if (Input.GetButtonDown("Fire1"))
		{
			// Shoot gun
			if (ammo >= 1) {
				// Play sound here when added
				Rigidbody clone;
				clone = (Rigidbody)Instantiate(projectile, target.position, target.rotation);
				clone.velocity = target.TransformDirection (Vector3.forward*shootSpeed*Time.deltaTime);
				ammo --;
			}
			// Jam gun
			else {
				// Play sound here when added
				print("Out of ammo!");
			}
		}
	}
}
