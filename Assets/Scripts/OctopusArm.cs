using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusArm : MonoBehaviour {

	public int direction = 1; 
	public float slowFactor = 3f; 
	public float linksDistanceFactor = 0.8f; 
	public float heightFactor = 0.5f; 

	public float minHeight = 0f; 
	public float maxHeight = 2.5f; 
	public float minDistance = 0.2f; 
	public float maxDistance = 2.2f; 

	private const KeyCode RIGHT = KeyCode.D;
	private const KeyCode LEFT = KeyCode.A;

	private int _direction; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		/* ===== Movement ==== */

		switch (direction) {

		case 1: //Right
			if (Input.GetKey (RIGHT)) { //move right
				ExpandAllLinks();
			} else { //move left
				ContractAllLinks();
			}
			break; 
		case -1: //Left
			if (Input.GetKey (LEFT)) { //move left
				ExpandAllLinks();
			} else { //move right
				ContractAllLinks();
			}
			break; 
		}
	}


	private void ExpandAllLinks(){
		OctopusArmLink[] links = GetComponentsInChildren<OctopusArmLink>();
		foreach (OctopusArmLink oal in links) {
			Expand ();
			//oal.updateFromArm ();
		}
	}
	private void ContractAllLinks(){
		OctopusArmLink[] links = GetComponentsInChildren<OctopusArmLink>();
		foreach (OctopusArmLink oal in links) {
			Contract ();
			//oal.updateFromArm ();
		}
	}


	//TODO: understand why clamp doesnt work perfect.

	private float ChangeHeight(float factor){
		heightFactor = Mathf.Clamp(heightFactor * factor, minHeight, maxHeight); 
		return heightFactor;
	}
	private float ChangeDistance(float factor){
		linksDistanceFactor = Mathf.Clamp(linksDistanceFactor * factor, minDistance, maxDistance); 
		return linksDistanceFactor;
	}
	private float ChangeSpeed(float factor){
		slowFactor *= factor; 
		return slowFactor;
	}

	public void Expand(){
		ChangeHeight (0.95f);
		ChangeDistance (1.05f);
	}
	public void Contract(){
		ChangeDistance (0.995f);
		ChangeHeight (1.005f);
	}
		
}
