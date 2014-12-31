using UnityEngine;
using System.Collections;

public class LoadLevelWhenDeath : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<damageHandler> ().health == 0) {
			Invoke("LoadLevel", 2f);		
		}
	}
	void LoadLevel(){
		Application.LoadLevel (levelName);
	}
}
