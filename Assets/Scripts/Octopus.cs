using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour {

	private HashSet<int> hurt;
	private shakeyCam sc;
	private GameManager _score;
	private float maxY = 2f;
	private float minY = -3f;
	public float smoothTime = 1F;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		sc  = GetComponent<shakeyCam> ();
		_score = GetComponentInParent<GameManager> ();
		hurt = new HashSet<int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (Input.GetKey (KeyCode.W)) { //up 
			Vector3 targetPosition = new Vector3(transform.position.x, maxY, transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}
		else if (Input.GetKey (KeyCode.S)) { //down
			Vector3 targetPosition = new Vector3(transform.position.x, minY, transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}
	}


	public void Hit(Collider other){
		if (!hurt.Contains (other.GetInstanceID ())) {
			hurt.Add (other.GetInstanceID ());
		
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


}


