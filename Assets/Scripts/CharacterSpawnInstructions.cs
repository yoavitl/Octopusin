using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawnInstructions {

	public static int POINT1 = 0; 
	public static int POINT2 = 1; 
	public static int POINT3 = 2; 
	public static int ENEMY1 = 3; 
	public static int ENEMY2 = 4; 
	public static int ENEMY3 = 5; 
	public static int STATIC1 = 6; 
	public static int STATIC2 = 7; 
	public static int STATIC3 = 8; 

	public float launchTime; 
	public float growthRate;
	public float decelrationRate;
	public Vector3 startPosition; 
	public int characterType; //from static ints //TODO: replace with Enums

	public CharacterSpawnInstructions(
		int characterType, 
		float launchTime, 
		float x, float y, float z, 
		float growthRate, 
		float decelrationRate){

		characterType = characterType; 
		launchTime = launchTime; 
		startPosition = new Vector3 (x, y, z);
		growthRate = growthRate; 
		decelrationRate = decelrationRate;
	}


}
