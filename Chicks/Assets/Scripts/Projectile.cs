﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int damage = 1;
	public int time = 5;
	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyProjectile());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator DestroyProjectile(){
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}