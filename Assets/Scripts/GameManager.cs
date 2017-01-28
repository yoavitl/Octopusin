using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
	public Image[] images;
	public int i = 2;

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
		level1.Add (new CharacterSpawnInstructions(0, 1f, 1f, -1f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(1, 5f, -3f, -1f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 9f, 4f, -2.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(0, 10f, 3f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(1, 11f, 4f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(2, 14f, 0f, -1f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(0, 16f, 2f, -1f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(1, 16.1f, 2f, -1f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(2, 18.2f, 2f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 20.3f, 2f, -1.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(4, 22.3f, 2f, -4.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(0, 23.2f, 2f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(6, 26.3f, 2f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 28f, 2f, -2.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(0, 31f, 2f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(1, 35f, -2f, -2.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(2, 39f, 2f, -0.2f, 15f, 0.01f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(0, 40f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(1, 41f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(2, 42f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 43f, 2f, -3.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(1, 43.1f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(2, 43.2f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 44.3f, 2f, -2.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 44.3f, 2f, -1.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(0, 44.2f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(6, 45.3f, 2f, -0.2f, 15f, 0.1f, 0.1f));
		level1.Add (new CharacterSpawnInstructions(3, 45.4f, 2f, -1.2f, 15f, 0.1f, 0.1f));
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
			movingObj mo = go.GetComponent<movingObj> ();
			mo.growthRate = -csi.growthRate; 
			mo.decelrationRate = csi.decelrationRate;
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
		if (health < 0.25f) {
			SceneManager.LoadScene ("GameOver");
		}
		Color c = images[i].color;
		if (c.a > 0) {
			c.a -= 0.25f;
			images [i].color = c;
		} else if (c.a == 0) { 
			i -= 1;
			c = images[i].color;
			c.a -= 0.25f;
			images [i].color = c;
		}
			
		Debug.Log ("Current health = " + health);
	}

}
