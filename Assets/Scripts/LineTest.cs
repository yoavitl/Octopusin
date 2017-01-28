using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour {

	private LineRenderer lr; 
	public int points = 30;
	public float r = 0.2f;
	public float xSpeed = 0.2f;
	public float heightFactor = 1f;
	public List<float> yHistory = new List<float>(); 
	public GameObject linkPrefab;
	private GameObject[] links;
	public int diretion = 1;

	// Use this for initialization
	void Start () {
		links = new GameObject[points];
		for (int i = 0; i < points; i++) {
			yHistory.Add(this.transform.position.y);
			GameObject currLink = (GameObject)GameObject.Instantiate (linkPrefab, this.transform.position, Quaternion.identity);
			links [i] = currLink;
			currLink.transform.parent = this.transform;
		}


		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x0 = assertFloat(0f); 
		float y0 = heightFactor * (Mathf.Sin (Time.time * xSpeed) % (Mathf.PI * 2));
		Vector3[] newPositions = new Vector3[points];
		//lt.SetPosition (0, new Vector3 (x0, y0, 0f));
		newPositions[0] = new Vector3 (x0, y0, 0f);
		yHistory.Insert (0, y0);
		yHistory.RemoveAt(yHistory.Count-1);
		float xi, yi, zi=0f;
		for (int i = 1; i < points; i++) {
			yi = assertFloat(yHistory [i - 1]);
			//xi = calcX1 (lr.GetPosition(i-1).x, r, lr.GetPosition(i-1).y, yi);
			xi = calcX1 (newPositions[i-1].x, r, newPositions[i-1].y, yi);
			links [i].transform.position = new Vector3 (xi, yi, zi);
			newPositions[i] = new Vector3 (xi, yi, zi);
		}
		lr.SetVertexCount (points);
		lr.SetPositions (newPositions);
		UpdateMovemetVars ();
	}

	private float calcX1 (float x2, float r, float y2, float y1){
		float sqrtContent = (r * r) - Mathf.Pow ((y2 - y1), 2f); 
		if (sqrtContent < 0f) {
			sqrtContent = 0f;
		}
		return x2 - Mathf.Sqrt (sqrtContent);
	}

	private void UpdateMovemetVars(){
		if(diretion ==1 ){ //right arm
			if (Input.GetKey (KeyCode.A)) {
				xSpeed = Mathf.Clamp (xSpeed + 0.01f, 0f, 2f);
				heightFactor = Mathf.Clamp (heightFactor - 0.05f, 0.9f, 1.1f);
			} else {
				xSpeed = Mathf.Clamp (xSpeed - 0.005f, 0f, 2f);
				heightFactor = Mathf.Clamp (heightFactor + 0.05f, 0.9f, 1.1f);
			}
		}
		else if(diretion ==-1 ){ //left arm
			if (Input.GetKey (KeyCode.D)) {
				xSpeed = Mathf.Clamp (xSpeed + 0.01f, 0f, 2f);
				heightFactor = Mathf.Clamp (heightFactor - 0.05f, 0.9f, 1.1f);
			} else {
				xSpeed = Mathf.Clamp (xSpeed - 0.005f, 0f, 2f);
				heightFactor = Mathf.Clamp (heightFactor + 0.05f, 0.9f, 1.1f);
			}
		}

	}

	private float assertFloat(float num){
		if(float.IsNaN(num) || num == null){
			return 0f;
		}
		else return num;
	}
}
