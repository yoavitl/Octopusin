using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusArm : MonoBehaviour {

	public int direction = 1; 
	public int delay = 10;
	public float linkDistance = 0.25f;
	public float slowFactor = 0.7f;
	public float linksDistanceFactor = 0.05f;
	public float heightFactor = 0.9f;
	public float HeightIncreaseSpeed = 0.005f;
	public float HeightDecreaseSpeed = 0.1f;
	public float minHeight = 0.5f; 
	public float maxHeight = 2.5f; 
	public float DistanceIncreaseSpeed = 0.1f; 
	public float DistanceDecreaseSpeed = 0.005f; 
	public float minDistance = 0.1f; 
	public float maxDistance = 10f; 
	public List<float> history = new List<float>();
	private OctopusArmLink _firstChild;

	private const KeyCode RIGHT = KeyCode.D;
	private const KeyCode LEFT = KeyCode.A;


	// Use this for initialization
	void Start () {
		resetHistory ();
	}
	
	// Update is called once per frame
	void Update () {
		SetMovementConstants ();
		history.Insert (0, _firstChild.transform.position.y);
		history.RemoveAt (history.Count-1);
	}

	void FixedUpdate() {

	}

	private void SetMovementConstants(){
		if (direction == 1) {
			if (Input.GetKey(RIGHT)) {
				linksDistanceFactor = Mathf.Clamp(linksDistanceFactor + DistanceIncreaseSpeed, minDistance, maxDistance);
				heightFactor = Mathf.Clamp(heightFactor - HeightDecreaseSpeed, minHeight, maxHeight);
			} else {
				linksDistanceFactor = Mathf.Clamp(linksDistanceFactor - DistanceDecreaseSpeed, minDistance, maxDistance);
				heightFactor = Mathf.Clamp(heightFactor + HeightIncreaseSpeed, minHeight, maxHeight);
			}
		}
		if (direction == -1) {
			if (Input.GetKey(LEFT)) {
				linksDistanceFactor = Mathf.Clamp(linksDistanceFactor + DistanceIncreaseSpeed, minDistance, maxDistance);
				heightFactor = Mathf.Clamp(heightFactor - HeightDecreaseSpeed, minHeight, maxHeight);
			} else {
				linksDistanceFactor = Mathf.Clamp(linksDistanceFactor - DistanceDecreaseSpeed, minDistance, maxDistance);
				heightFactor = Mathf.Clamp(heightFactor + HeightIncreaseSpeed, minHeight, maxHeight);
			}
		}
	}

	void resetHistory(){
		_firstChild = GetComponentsInChildren<OctopusArmLink> () [0];
		int childNum = transform.childCount;
		int historyLength = childNum * delay;
		for (int i = 0; i < historyLength; i++) {
			history.Insert (0,_firstChild.transform.position.y);
		}
	}

		
}
