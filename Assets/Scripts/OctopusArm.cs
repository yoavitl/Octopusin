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


	private int _direction; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
