using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	public Rigidbody projectile;
	public Transform target;
	public int shootSpeed, ammo;
	public Text ammoText;
	
	// Update is called once per frame
	void Update () {
		ammoText.text = ammo.ToString();
		if (Input.GetButtonDown("Fire1"))
		{
			if (ammo >= 1) {
				Rigidbody clone;
				clone = (Rigidbody)Instantiate(projectile, target.position, target.rotation);
				clone.velocity = target.TransformDirection (Vector3.forward*shootSpeed*Time.deltaTime);
				ammo --;
			}
			else {
				print("Out of ammo!");
			}
		}
	}
}
