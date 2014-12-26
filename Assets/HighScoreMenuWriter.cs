using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreMenuWriter : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().text = "HighScore : " + PlayerPrefs.GetInt("highScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
