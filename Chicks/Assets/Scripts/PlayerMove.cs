using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	
	public float moveSpeed, turnSpeed;
	// public float jumpHeight; // Not used due to removal of Jump function
	public Rigidbody rigid;

	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	void Update() {
		// Move player
		var h = Input.GetAxis("Horizontal")* Time.deltaTime * turnSpeed;
		var v = Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed;
		transform.Rotate(0,h,0);
		transform.Translate(0,0,v);
	}

	// Allow player to jump when touching floor. (Not used)
	// void OnCollisionStay(Collision other) {
	// 	if (other.gameObject.tag == "Floor") {
	// 		var j = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
	// 		rigid.AddForce(0,j,0);
	// 	}
    // }
}
