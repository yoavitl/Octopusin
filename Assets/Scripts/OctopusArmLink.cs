using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusArmLink : MonoBehaviour {

	private int _armIndex;
	private OctopusArm _arm; 
	public float _slowFactor; 
	public float _linksDistanceFactor; 
	public float _heightFactor;
	private float _minHeight;
	private float _maxHeight;
	private float _minDistance;
	private float _maxDistance;
	private int _direction; 

	private const KeyCode RIGHT = KeyCode.D;
	private const KeyCode LEFT = KeyCode.A;



	// Use this for initialization
	void Start () {
		updateIndex ();
		_arm = GetComponentInParent<OctopusArm> ();
		_slowFactor = _arm.slowFactor;
		_linksDistanceFactor = _arm.linksDistanceFactor;
		_direction = _arm.direction; 
		_minHeight = _arm.minHeight;
		_maxHeight = _arm.maxHeight;
		_minDistance = _arm.minDistance;
		_maxDistance = _arm.maxDistance;
		_heightFactor = _arm.heightFactor;

	}

	// Update is called once per frame
	void Update () {
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

	void FixedUpdate() {
		/* ===== Movement ==== */
	
		switch (_direction) {

		case 1: //Right
			if (Input.GetKey (RIGHT)) { //move right
				Expand();
			} else { //move left
				Contract();
			}
			break; 
		case -1: //Left
			if (Input.GetKey (LEFT)) { //move left
				Expand();
			} else { //move right
				Contract();
			}
			break; 
		}
	}


	//TODO: understand why clamp doesnt work perfect.

	private float ChangeHeight(float factor){
		_heightFactor = Mathf.Clamp(_heightFactor * factor, _minHeight, _maxHeight); 
		return _heightFactor;
	}
	private float ChangeDistance(float factor){
		_linksDistanceFactor = Mathf.Clamp(_linksDistanceFactor * factor, _minDistance, _maxDistance); 
		return _linksDistanceFactor;
	}
	private float ChangeSpeed(float factor){
		_slowFactor *= factor; 
		return _slowFactor;
	}

	private void Expand(){
		ChangeHeight (0.95f);
		ChangeDistance (1.05f);
	}
	private void Contract(){
		ChangeDistance (0.995f);
		ChangeHeight (1.005f);
	}


	public int updateIndex(){
		_armIndex = transform.GetSiblingIndex ();
		return _armIndex;
	}



}
