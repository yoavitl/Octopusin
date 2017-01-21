using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour {

	private HashSet<int> hurt;
	private shakeyCam sc;
	private GameManager _score;

	// Use this for initialization
	void Start () {
		sc  = GetComponent<shakeyCam> ();
		_score = GetComponentInParent<GameManager> ();
		hurt = new HashSet<int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(Collider other){
		if(!hurt.Contains(other.GetInstanceID())){
			hurt.Add (other.GetInstanceID ());
		}
		if (other.tag == "Point") {
			Debug.Log ("add a point");
			_score.AddScore (1);
		} else if (other.tag == "Enemy") {
			Debug.Log ("Remove Life");
			sc.Shake ();
			_score.RemoveLife ();
		} 
	}


}


