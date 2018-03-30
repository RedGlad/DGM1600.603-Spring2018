using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavChickenAI : MonoBehaviour {

	public float roamDistance;
	public float maxWanderTime;

	Transform target;
	UnityEngine.AI.NavMeshAgent agent;
	float timer;
	float wanderTime;

	// Use this for initialization
	void OnEnable () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		timer = wanderTime;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= wanderTime) {
			Vector3 newPos = RandomNavSphere(transform.position, roamDistance, -1);
			agent.SetDestination(newPos);
			timer = 0;
			wanderTime = Random.Range(0,maxWanderTime);
		}
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = Random.insideUnitSphere * dist;
		randDirection += origin;
		UnityEngine.AI.NavMeshHit navHit;
		UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
		return navHit.position;
	}
}
