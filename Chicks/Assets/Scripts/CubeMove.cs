using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
	
	public float moveSpeed;
	public float turnSpeed;
	public float jumpHeight;
	public Rigidbody rigid;
	public Transform spawnPoint0, spawnPoint1, spawnPoint2;

	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	void OnCollisionStay() {
		// Move();
    }

	void Update() {
		var j = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
		var h = Input.GetAxis("Horizontal")* Time.deltaTime * turnSpeed;
		var v = Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed;
		//var j2 = rotator.TransformDirection(Vector3.up*jumpHeight);
		
		rigid.AddForce(0,j,0);
		// transform.Translate(0,j,0);
		transform.Rotate(0,h,0);
		transform.Translate(0,0,v);
	// }
	// void Update(){
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
