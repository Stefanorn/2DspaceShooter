using UnityEngine;
using System.Collections;

public class LifeTrackerUI : MonoBehaviour {

	RectTransform image;
	int imageWith = 37;

	// Use this for initialization
	void Start () {
		image = GetComponent <RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		image.sizeDelta = new Vector2 (imageWith * PlayerSpawner.numLives, 26);
	
	}
}
