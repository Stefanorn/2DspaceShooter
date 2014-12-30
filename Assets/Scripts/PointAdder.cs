using UnityEngine;
using System.Collections;

public class PointAdder : MonoBehaviour {

	public int points = 10; 
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col) 
	{
		if(col.gameObject.layer == 12)
				ScoreTracker.AddPoint (points);

	}
}
