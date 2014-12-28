using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreTracker : MonoBehaviour {

	static int scoreTracker = 0;
	static int[] highScore = new int[10];
	Text textBox;

	// Use this for initialization
	void Start () 
	{
		textBox = GetComponent <Text> ();
		highScore[0] = PlayerPrefs.GetInt ("highScoreNr0");

		for (int i = 0; i < highScore.Length; i++) {
			highScore[i] = PlayerPrefs.GetInt("highScoreNr" + i);
		}
			
	}
	static public void ResetScore(){
		scoreTracker = 0;
		//Raðar HighScore
		IntArrayBubbleSort (highScore);
		//Situr Allan listan i playerPrefs
		for (int i = 0; i < highScore.Length; i++) {
			PlayerPrefs.SetInt("highScoreNr" + i , highScore[i]);		
		}
	}
	static public void AddPoint(int points)
	{
		//Bætir inn points og addar þvi svo aftast i highscoreListan ef a við
		scoreTracker = scoreTracker + points;
		if (scoreTracker > highScore[0]) {
			highScore[0] = scoreTracker;
		}
	}
	void OnDestroy()
	{
	}
	// Update is called once per frame
	void Update () {
		int displayHighscore;
		if (highScore [9] > highScore [0]) {
						displayHighscore = highScore [9];
				} 
		else {
			displayHighscore = highScore[0];
		}
		textBox.text = "    Score : " + scoreTracker + " \n" +
			"highScore : " + displayHighscore;
	}


	static void IntArrayBubbleSort (int[] data)
	{
		int i, j;
		int N = data.Length;
		
		for (j=N-1; j>0; j--) {
			for (i=0; i<j; i++) {
				if (data [i] > data [i + 1])
					exchange (data, i, i + 1);
			}
		}
	}

	static void exchange (int[] data, int m, int n)
	{
		int temporary;
		
		temporary = data [m];
		data [m] = data [n];
		data [n] = temporary;
	}

}
