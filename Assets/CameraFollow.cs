using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{
	private bool shaking;
	private Transform _transform;

	public float speed = 0.7f;

	void Start (){
		_transform = this.transform;
	}
		
	void Update (){
		_transform.localPosition = new Vector3(_transform.position.x, Mathf.Sin (Time.time) * speed, _transform.position.z);	


	}


}


