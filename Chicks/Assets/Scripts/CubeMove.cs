using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
	
	public float moveSpeed, turnSpeed, jumpHeight;
	public Rigidbody rigid;
	public Transform spawnPoint0, spawnPoint1, spawnPoint2;

	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	void OnCollisionStay(Collision other) {
		if (other.gameObject.tag == "Floor") {
			Jump();
		}
    }
	void Jump() {
		var j = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
		rigid.AddForce(0,j,0);
	}
	void Update() {
		var h = Input.GetAxis("Horizontal")* Time.deltaTime * turnSpeed;
		// var v = Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed; // Input Speed
		var v = moveSpeed * Time.deltaTime; // Constant Speed
		// var xMath = transform.rotation.x * Time.deltaTime * 1000;
		
		transform.Rotate(0,h,0);
		transform.Translate(0,0,v); //set move speed around 10
		// rigid.AddForce(transform.TransformDirection(Vector3.forward)*v); //set move speed around 1000
		// rigid.AddForce(0,0,xMath);

		// teleportation section
		if (Input.GetKeyDown(KeyCode.RightBracket)) {
			transform.SetPositionAndRotation(rigid.transform.position + new Vector3(0,0.5f,0), new Quaternion(0,0,0,0));
		}
		if (Input.GetKeyDown(KeyCode.LeftBracket)) {
			transform.position = spawnPoint0.position;
		}
		if (Input.GetKeyDown(KeyCode.Quote)) {
			transform.position = spawnPoint1.position;
		}
		if (Input.GetKeyDown(KeyCode.Semicolon)) {
			transform.position = spawnPoint2.position;
		}
	}
}
