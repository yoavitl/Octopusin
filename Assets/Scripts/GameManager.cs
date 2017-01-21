using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public bool isDemo = true;
	public bool currentlyPlaying = true;
	private List<CharacterSpawnInstructions> level1;
	//private List<CharacterSpawnInstructions> level2; //TODO: level2
	private GameObject _characters; 
	public GameObject[] characterPrefabs;
	public float startingDistance = 30f;
	public Text scoreBoard;

	public int Score;
	public float health; 

	// Use this for initialization
	void Start () {
		Score = 0;
		health = 3f;

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
		level1 = new List<CharacterSpawnInstructions> ();
		level1.Add (new CharacterSpawnInstructions(CharacterSpawnInstructions.POINT1, 1f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(CharacterSpawnInstructions.ENEMY1, 5f, -2f, -2.2f, 15f, 0.1f, 0.1f));
		/*level1.Add (new KeyValuePair<int, float> (ENEMY2, 6f));
		level1.Add (new KeyValuePair<int, float> (STATIC2, 10f));
		level1.Add (new KeyValuePair<int, float> (ENEMY3, 12f));
		level1.Add (new KeyValuePair<int, float> (STATIC3, 13f));
		level1.Add (new KeyValuePair<int, float> (STATIC2, 15f));
		level1.Add (new KeyValuePair<int, float> (POINT2, 16f));
		level1.Add (new KeyValuePair<int, float> (POINT2, 17f));
		level1.Add (new KeyValuePair<int, float> (POINT3, 17f));
		level1.Add (new KeyValuePair<int, float> (STATIC3, 18f));
		level1.Add (new KeyValuePair<int, float> (ENEMY2, 21f));
		level1.Add (new KeyValuePair<int, float> (ENEMY2, 22f));*/
	}

	private void LaunchLevel(List<CharacterSpawnInstructions> levelDescription){
		foreach (CharacterSpawnInstructions csi in levelDescription) {
			StartCoroutine (generateElement (csi));
		}
	}
		
	private IEnumerator generateElement(CharacterSpawnInstructions csi){
		if (currentlyPlaying) {
			//print ("adding point " + id + " in " + delay + " seconds");
			yield return new WaitForSeconds (csi.launchTime);
			GameObject go = (GameObject)GameObject.Instantiate (characterPrefabs [csi.characterType], csi.startPosition, Quaternion.identity);
			//movingObj mo = go.GetComponent<movingObj> ();
			//mo.growthRate = csi.growthRate; 
			//mo.decelrationRate = csi.decelrationRate;
			go.transform.parent = _characters.transform;
		} else {
			// Lost / Paused
		}
	}

	public void AddScore (int newScoreValue)
	{
		Score += newScoreValue;
		scoreBoard.text = ("Current Score: " + Score);
	}

	public void RemoveLife ()
	{
		health -= 0.25f;
		Debug.Log ("Current health = " + health);
	}

}
