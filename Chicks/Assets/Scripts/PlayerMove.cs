using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	
	public float moveSpeed, turnSpeed;
	// public float jumpHeight;
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

	// This section was for jump functionality, which I decided isn't necessary for this game
	// Still keeping the code, just in case.

	// void OnCollisionStay(Collision other) {
	// 	if (other.gameObject.tag == "Floor") {
	// 		var j = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
	// 		rigid.AddForce(0,j,0);
	// 	}
    // }
}
