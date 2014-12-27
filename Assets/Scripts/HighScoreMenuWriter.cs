using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreMenuWriter : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().text =
				"1 " + PlayerPrefs.GetInt("highScoreNr9", 0) + "\n " + 
				"2 " + PlayerPrefs.GetInt("highScoreNr8", 0) + "\n " + 
				"3 " + PlayerPrefs.GetInt("highScoreNr7", 0) + "\n " + 
				"4 " + PlayerPrefs.GetInt("highScoreNr6", 0) + "\n " + 
				"5 " + PlayerPrefs.GetInt("highScoreNr5", 0) + "\n " + 
				"6 " + PlayerPrefs.GetInt("highScoreNr4", 0) + "\n " + 
				"7 " + PlayerPrefs.GetInt("highScoreNr3", 0) + "\n " + 
				"8 " + PlayerPrefs.GetInt("highScoreNr2", 0) + "\n " + 
				"9 " + PlayerPrefs.GetInt("highScoreNr1", 0) + "\n " + 
				"10 " + PlayerPrefs.GetInt("highScoreNr0", 0) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
