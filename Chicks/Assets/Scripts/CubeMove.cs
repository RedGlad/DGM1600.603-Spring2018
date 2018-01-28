using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
	
	public float moveSpeed;
	public float turnSpeed;
	public float jumpHeight;
	public Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	 void FixedUpdate () {
		var j = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
		var h = Input.GetAxis("Horizontal")* Time.deltaTime * turnSpeed;
		var v = Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed;
		
		rigid.AddForce(0,j,0);
		// transform.Translate(0,j,0);
		transform.Rotate(0,h,0);
		transform.Translate(0,0,v);
    }
}
