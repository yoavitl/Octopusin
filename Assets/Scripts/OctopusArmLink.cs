using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusArmLink : MonoBehaviour {

	private int _armIndex;
	private OctopusArm _arm; 
	public float _slowFactor; 
	public float _linksDistanceFactor; 
	public float _heightFactor;
	private int _direction; 





	// Use this for initialization
	void Start () {
		updateIndex ();
		_arm = GetComponentInParent<OctopusArm> ();
		updateFromArm ();
	}

	public void updateFromArm(){
		_slowFactor = _arm.slowFactor;
		_linksDistanceFactor = _arm.linksDistanceFactor;
		_direction = _arm.direction; 
		_heightFactor = _arm.heightFactor;
	}

	// Update is called once per frame
	void Update () {
		updateFromArm ();
		updateIndex ();
		float x = (Time.time / _slowFactor) % (2f * Mathf.PI);
		float move = x + _armIndex;
		this.transform.position = new Vector2 (_armIndex * _linksDistanceFactor * _direction, Mathf.Sin (move) * _heightFactor);

		/*
		//TODO: fix rotation
		float rotation = Mathf.Clamp(Mathf.Cos (move), -0.2f, 0.2f);
		Quaternion oldRotation = this.transform.rotation;
		this.transform.Rotate ( new Vector3(oldRotation.x,oldRotation.y,rotation));
		*/


	}


	public int updateIndex(){
		_armIndex = transform.GetSiblingIndex ();
		return _armIndex;
	}



}
