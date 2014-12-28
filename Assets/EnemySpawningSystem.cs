using UnityEngine;
using System.Collections;

public class EnemySpawningSystem : MonoBehaviour {

	public GameObject[] enemys;
	string[] corutines = {"Box", "SnakeSpawnX"};
	public float spawnRate = 0.1f;
	int enemyPicker = 0;

	float xValue;
	float yValue;
	public float offset = 2f;
	Vector2 spawnLocation;

	void Start(){
		yValue = Camera.main.orthographicSize;
		xValue = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		spawnLocation.y = yValue;

		//StartCoroutine (corutines[Random.Range(0,corutines.Length)]);
		StartCoroutine (SnakeSpawnX ());
	}
	IEnumerator Box (){
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		StartCoroutine (XLine(1) );
		yield return new WaitForSeconds (spawnRate*((xValueMax /offset)*2) + offset);
		StartCoroutine (YLine(1) );
		yield return new WaitForSeconds (spawnRate*(Camera.main.orthographicSize * 2 /offset) + offset);
		StartCoroutine (XLine(-1) );
		yield return new WaitForSeconds (spawnRate*((xValueMax /offset)*2) + offset);
		StartCoroutine (YLine(-1) );
		yield return new WaitForSeconds (spawnRate*(Camera.main.orthographicSize * 2 / offset) + offset);

		Start ();
	}
	IEnumerator SnakeSpawnX(){
		xValue = 0f;
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		enemyPicker = Random.Range (0, enemys.Length);
		for(float f = 0; f < 50 ;f++ ){
			spawnLocation.x = xValue;
			Instantiate(enemys[enemyPicker], spawnLocation, Quaternion.Euler(0,0,180));
			Debug.Log(spawnLocation);
			xValue += Random.Range(-offset, offset);
			yield return new WaitForSeconds(spawnRate);
		}
		Start ();
	}
	IEnumerator XLine( float posOrNeg ){
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		xValue = -xValueMax * posOrNeg;
		for(float f = 0; f < (xValueMax/offset)*2 ;f++ ){
			spawnLocation.x = xValue;
			Instantiate(enemys[4], spawnLocation, Quaternion.Euler(0,0,90 * (1 + posOrNeg) ));
			xValue += offset *posOrNeg;
			yield return new WaitForSeconds(spawnRate);
		}
	}
	IEnumerator YLine( float posOrNeg ){
		float yValueMax = Camera.main.orthographicSize * 2;

		for(float f = 0; f < (yValueMax/offset) ;f++ ){
			spawnLocation.y = yValue;
			Instantiate(enemys[4], spawnLocation, Quaternion.Euler(0,0,90* posOrNeg));
			yValue -= offset * posOrNeg;
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
