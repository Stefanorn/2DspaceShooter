using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject[] enemys;

	float spawnDistance = 12f;
	float enemyRate = 4;
	float nextEnemy = 1;

	// Update is called once per frame
	void Update () {
		nextEnemy -= Time.deltaTime;

		if (nextEnemy <= 0) {
			nextEnemy = enemyRate;
			enemyRate *= 0.9f;
			if(enemyRate < 2){
				enemyRate = 1f;
			}
			Vector3 offset = Random.onUnitSphere;
			offset.z = 0;
			offset = offset.normalized * spawnDistance;

			int enemyPicker = Random.Range(0, enemys.Length);
			Instantiate(enemys[enemyPicker], transform.position + offset, Quaternion.identity);
		}
	}
}
