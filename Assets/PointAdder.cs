using UnityEngine;
using System.Collections;

public class PointAdder : MonoBehaviour {

	public int points = 10; 
	
	// Update is called once per frame
	void OnTriggerEnter2D () 
	{
		ScoreTracker.AddPoint (points);
	}
}
