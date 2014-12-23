using UnityEngine;
using System.Collections;

public class UITextScrollingScript : MonoBehaviour {

	float startDelay = 2f;
	float scrollSpeed = 5f;
	bool stop = false;
	bool stop2 = true;

	Vector2 startingPos;
	RectTransform recktTransform;
	TextMesh text;
	Level1EnemySpawner enemySpawner;
	// Use this for initialization
	void Start () {
		enemySpawner = GetComponentInParent< Level1EnemySpawner> ();
		text = GetComponent<TextMesh> ();
		recktTransform = GetComponent<RectTransform> ();
		startingPos = recktTransform.anchoredPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemySpawner.stop && stop && stop2) {
			recktTransform.anchoredPosition = startingPos;
			text.text = "BIG WAVE INCOMING";
			stop = false;
			stop2 = false;
			
		}
		if (stop) {
			return;
		}
		startDelay = startDelay - Time.deltaTime;

		if (startDelay <= 0) {
			Vector2 pos = recktTransform.anchoredPosition;
			Vector2 vel = new Vector2 (0, scrollSpeed*Time.deltaTime);
			pos += vel;

			recktTransform.anchoredPosition = pos;
		}
	
	}
	void OnBecameInvisible()
	{
		
		stop = true;
		startDelay = 2f;
	}
}
