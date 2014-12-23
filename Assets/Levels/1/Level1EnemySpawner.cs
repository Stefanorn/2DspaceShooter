using UnityEngine;
using System.Collections;

public class Level1EnemySpawner : MonoBehaviour {

	public GameObject[] enemys;
	
	float spawnDistance = 15f;
	float enemyRate = 5;
	float nextEnemy = 1;
	int enemyCounter = 30;
	public bool stop = false;
	
	// Update is called once per frame
	void Update () {

		if (stop) {
			GameObject[] enemysLeft = GameObject.FindGameObjectsWithTag("enemy");
			int isGameOver = 0;
			foreach(GameObject enemyleft in enemysLeft){
				isGameOver++;
			}
				if(isGameOver == 0){
					Debug.Log("EndLevel");
					Application.LoadLevel("Level2");
			}
			return;		
		}

		nextEnemy -= Time.deltaTime;
		
		if (nextEnemy <= 0) {
			enemyCounter--;
			nextEnemy = enemyRate;
			enemyRate *= 0.9f;
			if(enemyRate < 2){
				enemyRate = 2;
			}
			Vector3 offset = Random.onUnitSphere;
			offset.z = 0;
			offset = offset.normalized * spawnDistance;

			if(enemyCounter > 0){
				Instantiate(enemys[0], transform.position + offset, Quaternion.identity);
			}

			if(enemyCounter <= 0){
				Instantiate(enemys[1], transform.position + offset, Quaternion.identity);
			}
			if(enemyCounter == -30){
				EndLevelwave();
			}
		}
	}
	void EndLevelwave(){
		for (int i = 1; i <= 20; i++) {
			Vector3 offset = new Vector3 (Random.Range(-30,-60), Random.Range( -spawnDistance, +spawnDistance), 0);
			Instantiate(enemys[Random.Range(0, enemys.Length)], transform.position + offset, Quaternion.Euler(0,0,90));
		}
		stop = true;
	}

}
