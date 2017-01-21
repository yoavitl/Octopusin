using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider))]
public class OctopusCollider : MonoBehaviour {

	private Octopus _octopus; 

	// Use this for initialization
	void Start () {
		_octopus = GetComponentInParent<Octopus> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Player"){
			_octopus.Hit (other);
		}
	}


}
