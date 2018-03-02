using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterListing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		List<Characters> char = new List<Characters>();
		char.Add(new Characters("Linda", 5,2));
		char.Add(new Characters("Slash", 3,3));
		char.Add(new Characters("Nancy", 2,5));
	}
}