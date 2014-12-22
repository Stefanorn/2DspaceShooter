using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreTracker : MonoBehaviour {

	static int scoreTracker = 0;
	static int highScore = 0;

	Text textBox;

	// Use this for initialization
	void Start () 
	{
		scoreTracker = 0;
		textBox = GetComponent <Text> ();
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	
	}
	static public void AddPoint(int points)
	{
		scoreTracker = scoreTracker + points;
		if (scoreTracker > highScore) {
			highScore = scoreTracker;
		}
	}
	void OnDestroy()
	{
		PlayerPrefs.SetInt ("highScore", highScore);
	}
	// Update is called once per frame
	void Update () {
		textBox.text = "Score : " + scoreTracker;
	}
}
