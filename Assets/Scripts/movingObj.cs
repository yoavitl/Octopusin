using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObj : MonoBehaviour {
	public Camera cam;
	private Transform _transform;
	public float growthRate;
	public float decelrationRate;

	void Start () {
		cam = Camera.main;
		_transform = this.transform;
	}

	// Update is called once per frame
	void Update () {
		_transform.localPosition = new Vector3 (_transform.position.x, _transform.position.y, _transform.position.z + growthRate/decelrationRate);
		_transform.localScale += new Vector3 (growthRate/100 , growthRate/100, 0);

<<<<<<< HEAD
		if (_transform.position.z > cam.transform.position.z) 
			Destroy (gameObject);	
=======
		if (_transform.position.z < cam.transform.position.z) {
			Destroy (gameObject);        
		}
>>>>>>> 9161a108c96f7c207575e3b9d4198b803e763867
	}


}