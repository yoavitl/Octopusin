using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAnimation : MonoBehaviour {
	private Transform _transform;
	public Camera cam;

	public double GetAngle(Vector2 a, Vector2 b)
	{
		double angle = Mathf.Atan2 (a.y - b.y, a.x - b.x);
		//Debug.Log (angle);
		return angle;
	}

	void Start () {
		cam = Camera.main;
		_transform = this.transform;
	}

	// Update is called once per frame
	void Update () {
		GetAngle(new Vector2(_transform.localPosition.y,_transform.localPosition.z), new Vector2(cam.transform.position.y,cam.transform.position.z));
}
}
