using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusArmLink : MonoBehaviour {


	private int _armIndex;
	private OctopusArm _arm; 
	
	public Queue<float> previousLinkYLocations; 
	public Queue<float> previousLinkXLocations; 

	// Use this for initialization
	void Start () {
		updateIndex ();
		_arm = GetComponentInParent<OctopusArm> ();
		previousLinkXLocations = new Queue<float>();
		previousLinkYLocations = new Queue<float>();
		for (int i = 0; i < _arm.delay; i++) {
			previousLinkYLocations.Enqueue(transform.position.y);
			previousLinkYLocations.Enqueue(transform.position.x);
		}
	}

	public void updateFromArm(){

	}

	// Update is called once per frame
	void Update () {
		updateIndex ();
		float x, y;
		if (_armIndex == 0) {
			x = _arm.direction;
			float h = (Time.time / _arm.slowFactor) % (2f * Mathf.PI);
			y = Mathf.Sin (h) * _arm.heightFactor;
		} else {
			previousLinkXLocations.Enqueue (transform.parent.GetChild (_armIndex - 1).transform.position.x);
			x = previousLinkXLocations.Dequeue () + (_armIndex * _arm.linksDistanceFactor * _arm.direction) ;
			previousLinkYLocations.Enqueue (transform.parent.GetChild (_armIndex - 1).transform.position.y);
			y = previousLinkYLocations.Dequeue ();
		}
		this.transform.position = new Vector2 (x, y);
	}

	void FixedUpate(){


	}


	public int updateIndex(){
		_armIndex = transform.GetSiblingIndex ();
		return _armIndex;
	}


}
