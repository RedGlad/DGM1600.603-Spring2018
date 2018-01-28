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
		var y = Input.GetAxis("Jump")* Time.deltaTime * jumpHeight;
		var x = Input.GetAxis("Horizontal")* Time.deltaTime * turnSpeed;
		var z = Input.GetAxis("Vertical")* Time.deltaTime * moveSpeed;
		
		rigid.AddForce(0,y,0);
		// transform.Translate(0,j,0);
		rigid.AddForce(x,0,0);
		rigid.AddForce(0,0,z);
    }
}
