using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTest : MonoBehaviour {

	private LineRenderer lr; 
	public int points = 30;
	public float r = 0.2f;
	public float xSpeed = 0.2f;
	public List<float> yHistory = new List<float>(); 

	// Use this for initialization
	void Start () {
		for (int i = 0; i < points; i++) {
			yHistory.Add(this.transform.position.y);
		}
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x0 = assertFloat(0f); 
		float y0 = assertFloat(Mathf.Sin (Time.time * xSpeed) % (Mathf.PI * 2));
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
		if(Input.GetKey(KeyCode.A)){
			xSpeed = Mathf.Clamp(xSpeed - 0.05f, 0f, 2f);
		}
		if(Input.GetKey(KeyCode.D)){
			xSpeed = Mathf.Clamp(xSpeed + 0.05f, 0f, 2f);
		}
	}

	private float assertFloat(float num){
		if(float.IsNaN(num) || num == null){
			return 0f;
		}
		else return num;
	}
}
