using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerPrefab;
	public static int numLives = 4;

	GameObject playerInstance;


	float respawnTimer;

	// Use this for initialization
	void Start () {
		if (numLives > 0) {
			spawnPlayer ();
		}
		
	
	}
	void spawnPlayer(){
		numLives--;
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
}
