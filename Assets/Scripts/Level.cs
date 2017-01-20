using System.Collections;
using System.Collections.Generic;


public class Level {

	private int _difficulty; 
	private int _seconds; 
	private List<KeyValuePair<int, float>> level;

	public Level (int difficulty, int time){
		_seconds = time; 
		_difficulty = difficulty;
		//TODO: create dynamic levels
	}

}
