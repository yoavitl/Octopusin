using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour {

	private HashSet<int> hurt;
	private shakeyCam sc;
	private GameManager _score;
	private float maxY = 5f;
	private float CameraMaxY = 1f;
	private float CameraMinY = -1f;
	private float minY = -10f;
	public float smoothTime = 2F;
	public float camRotationSpeed = 1f;
	private Vector3 velocity = Vector3.zero;
	private Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
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
			Vector3 CameraTargetPosition = new Vector3(cam.transform.position.x, CameraMaxY, cam.transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
			cam.transform.position = Vector3.SmoothDamp(cam.transform.position, CameraTargetPosition, ref velocity, smoothTime);
		}
		else if (Input.GetKey (KeyCode.S)) { //down
			Vector3 targetPosition = new Vector3(transform.position.x, minY, transform.position.z);
			Vector3 CameraTargetPosition = new Vector3(cam.transform.position.x, CameraMinY, cam.transform	.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
			cam.transform.position = Vector3.SmoothDamp(cam.transform.position, CameraTargetPosition, ref velocity, smoothTime);
		}

	}


	public void Hit(Collider other){
		if (!hurt.Contains (other.GetInstanceID ())) {
			hurt.Add (other.GetInstanceID ());
			if (other.tag == "Point") {
				Debug.Log ("add a point");
				_score.AddScore (10);
			} else if (other.tag == "Enemy") {
				Debug.Log ("Remove Life");
				sc.Shake ();
				_score.RemoveLife ();
			} 
		}
	}


}


