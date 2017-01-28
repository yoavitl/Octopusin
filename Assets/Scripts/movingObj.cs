using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingObj : MonoBehaviour {
	public Camera cam;
	private Transform _transform;
	public float growthRate;
	public float decelrationRate;
	private Rigidbody _rb;

	void Start () {
		cam = Camera.main;
		_transform = this.transform;
		_rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (_transform.position.z < cam.transform.position.z) {
			Destroy (gameObject);        
		}
	}

	void FixedUpdate(){
		_rb.MovePosition(transform.position + new Vector3(0f,0f,growthRate/decelrationRate));
	}
}