using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	public int numLives = 4;

	GameObject playerInstance;


	float respawnTimer;

	// Use this for initialization
	void Start () {
		numLives--;
		if (numLives > 0) {
			spawnPlayer ();
		}
		
	
	}
	void spawnPlayer(){
		respawnTimer = 1f;
		playerInstance = (GameObject)Instantiate (playerPrefab, transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		if (playerInstance == null) {
			respawnTimer -= Time.deltaTime;

			if(respawnTimer <= 0){
				spawnPlayer();	
			}
		}
	
	}
	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 50), "Lives " + numLives);
	}
}
