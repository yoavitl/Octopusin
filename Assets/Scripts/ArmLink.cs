using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLink : MonoBehaviour {

	public int armIndex;
	public float slowFactor = 3;

	// Use this for initialization
	void Start () {
		updateIndex ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = (Time.time / slowFactor) % (2f * Mathf.PI);
		this.transform.position = new Vector2 (armIndex, Mathf.Sin (x + armIndex));
	}
		

	public int updateIndex(){
		armIndex = transform.GetSiblingIndex ();
		return armIndex;
	}
}
