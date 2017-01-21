using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusArmLink : MonoBehaviour {


	private int _linkIndex;
	private OctopusArm _arm; 
	private int t = 0;

	// Use this for initialization
	void Start () {
		updateIndex ();
		_arm = GetComponentInParent<OctopusArm> ();

	}

	public void updateFromArm(){

	}

	// Update is called once per frame
	void Update () {
		t++;
		updateIndex ();
		float x, y;
		if (_linkIndex == 0) {
			x = _arm.direction;
			float h = (Time.time / _arm.slowFactor) % (2f * Mathf.PI);
			y = Mathf.Sin (h) * _arm.heightFactor;
		} else {
			if (t > 500) {
				float x2 = transform.parent.transform.GetChild (_linkIndex - 1).transform.position.x;
				float y2 = transform.parent.transform.GetChild (_linkIndex - 1).transform.position.y;
				y = _arm.history [_linkIndex * _arm.delay]; 
				float sqrtContent = 
					Mathf.Pow (_arm.linkDistance, 2f) -
					Mathf.Pow ((y - y2), 2f);
			
				x = Mathf.Sqrt (sqrtContent) + Mathf.Pow (x2, 2f);
			} else {
				y = _arm.history [_linkIndex * _arm.delay]; 
				x = _arm.direction * _linkIndex * _arm.linksDistanceFactor;
			}
		}
		this.transform.position = new Vector2 (x, y);
	}

	void FixedUpate(){


	}


	public int updateIndex(){
		_linkIndex = transform.GetSiblingIndex ();
		return _linkIndex;
	}


}
