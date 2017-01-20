using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool isDemo = true;
	public bool currentlyPlaying = true;
	private List<KeyValuePair<int, float>> level1;
	//private List<KeyValuePair<int, float>> level2; //TODO: level2
	private GameObject _characters; 
	private const int POINT1 = 0; 
	private const int POINT2 = 1; 
	private const int POINT3 = 2; 
	private const int ENEMY1 = 3; 
	private const int ENEMY2 = 4; 
	private const int ENEMY3 = 5; 
	private const int STATIC1 = 6; 
	private const int STATIC2 = 7; 
	private const int STATIC3 = 8; 
	public GameObject[] characterPrefabs;
	public float startingDistance = 30f;

	// Use this for initialization
	void Start () {
		
		setExampleLevels ();
		_characters = GameObject.Find ("Characters");
		if (isDemo) {
			LaunchLevel (level1);
		} else {
			//TODO: real levels
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void setExampleLevels(){
		level1 = new List<KeyValuePair<int, float>> ();
		level1.Add (new KeyValuePair<int, float> (POINT1, 1f));
		level1.Add (new KeyValuePair<int, float> (ENEMY1, 5f));
		level1.Add (new KeyValuePair<int, float> (ENEMY2, 6f));
		level1.Add (new KeyValuePair<int, float> (STATIC2, 10f));
		level1.Add (new KeyValuePair<int, float> (ENEMY3, 12f));
		level1.Add (new KeyValuePair<int, float> (STATIC3, 13f));
		level1.Add (new KeyValuePair<int, float> (STATIC2, 15f));
		level1.Add (new KeyValuePair<int, float> (POINT2, 16f));
		level1.Add (new KeyValuePair<int, float> (POINT2, 17f));
		level1.Add (new KeyValuePair<int, float> (POINT3, 17f));
		level1.Add (new KeyValuePair<int, float> (STATIC3, 18f));
		level1.Add (new KeyValuePair<int, float> (ENEMY2, 21f));
		level1.Add (new KeyValuePair<int, float> (ENEMY2, 22f));
	}

	private void LaunchLevel(List<KeyValuePair<int, float>> levelDescription){
		foreach (KeyValuePair<int, float> kvp in levelDescription) {
			StartCoroutine (generateElement (kvp.Key, kvp.Value));
		}
	}
		
	private IEnumerator generateElement(int id, float delay){
		if (currentlyPlaying) {
			//print ("adding point " + id + " in " + delay + " seconds");
			yield return new WaitForSeconds (delay);
			GameObject go = (GameObject)GameObject.Instantiate (characterPrefabs [id], new Vector3 (0f, 0f, startingDistance), Quaternion.identity);
			go.transform.parent = _characters.transform;
		} else {
			// Lost / Paused
		}
	}

}
