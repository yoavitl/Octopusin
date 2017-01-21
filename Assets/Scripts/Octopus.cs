using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour {

	private HashSet<int> hurt;

	// Use this for initialization
	void Start () {
		hurt = new HashSet<int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(Collider other){
		if(!hurt.Contains(other.GetInstanceID())){
			hurt.Add (other.GetInstanceID ());

			Debug.Log ("hurt");

		}
	}


}
