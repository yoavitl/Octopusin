using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAnimation : MonoBehaviour {
	private Transform _transform;
	public Camera cam;
	private Animator animator;
	public float camAngle;

	public double GetAngle(Vector2 a, Vector2 b)
	{
		double angle = Mathf.Atan2 (a.y - b.y, a.x - b.x);
		camAngle = (float)angle;
		animator.SetFloat ("camAngle", (float)angle);
		//Debug.Log (angle);
		return angle;
	}

	void Start () {
		animator = GetComponent<Animator> ();
		cam = Camera.main;
		_transform = this.transform;
	}

	// Update is called once per frame
	void Update () {
		GetAngle(new Vector2(_transform.localPosition.y,_transform.localPosition.z), new Vector2(cam.transform.position.y,cam.transform.position.z));
}
}
