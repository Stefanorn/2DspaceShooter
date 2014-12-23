using UnityEngine;
using System.Collections;

public class UIScrolling3 : MonoBehaviour {


	float startDelay = 2f;
	float scrollSpeed = 5f;
	bool stop = false;
	RectTransform recktTransform;
	// Use this for initialization
	void Start () {
		recktTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
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