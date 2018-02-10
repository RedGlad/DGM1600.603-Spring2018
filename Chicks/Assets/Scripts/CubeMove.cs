using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
	
	public float moveSpeed;
	public float turnSpeed;
	public float jumpHeight;
	public float jumpSquash;
	public Rigidbody rigid;
	public Transform rotator;

	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	 void FixedUpdate () {
		var j = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
		var h = Input.GetAxis("Horizontal")* Time.deltaTime * turnSpeed;
		var v = Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed;
		//var j2 = rotator.TransformDirection(Vector3.up*jumpHeight);
		
		rigid.AddForce(0,j,0);
		// transform.Translate(0,j,0);
		transform.Rotate(0,h,0);
		transform.Translate(0,0,v);
    }
}
