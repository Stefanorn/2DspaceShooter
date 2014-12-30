using UnityEngine;
using System.Collections;

public class EnemySpawningSystem : MonoBehaviour {

	public GameObject[] enemys;
	public GameObject boss;
	string[] corutines = {"Box", "SnakeSpawnX","PingPongXAxis"};
	public int courutinesCounter = 5;
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

		courutinesCounter--;
		Debug.Log (courutinesCounter);
		if (courutinesCounter <= 0) {
			Instantiate(boss, new Vector2(0,9), Quaternion.identity);
		}
		else {
			StartCoroutine (corutines[Random.Range(0,corutines.Length)]);
		}
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
	IEnumerator XLine( float posOrNeg ){
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		xValue = -xValueMax * posOrNeg;
		for(float f = 0; f < (xValueMax/offset)*2 ;f++ ){
			spawnLocation.x = xValue;
			Instantiate(enemys[3], spawnLocation, Quaternion.Euler(0,0,90 * (1 + posOrNeg) ));
			xValue += offset *posOrNeg;
			yield return new WaitForSeconds(spawnRate);
		}
	}
	IEnumerator YLine( float posOrNeg ){
		float yValueMax = Camera.main.orthographicSize * 2;

		for(float f = 0; f < (yValueMax/offset) ;f++ ){
			spawnLocation.y = yValue;
			Instantiate(enemys[3], spawnLocation, Quaternion.Euler(0,0,90* posOrNeg));
			yValue -= offset * posOrNeg;
			yield return new WaitForSeconds(spawnRate);
		}
	}
	IEnumerator SnakeSpawnX(){
		xValue = 0f;
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		enemyPicker = Random.Range (0, enemys.Length);
		while (enemyPicker == 3 || enemyPicker == 0 ||enemyPicker == 4) { //Hvaða ovinir geta spawnað
			enemyPicker = Random.Range (0, enemys.Length);
			Debug.Log(enemyPicker);
		}
		for(float f = 0; f < 50 ;f++ ){
			spawnLocation.x = xValue;
			Instantiate(enemys[enemyPicker], spawnLocation, Quaternion.Euler(0,0,180));
			Debug.Log(spawnLocation);
			xValue += Random.Range(-offset, offset);
			yield return new WaitForSeconds(spawnRate*3);
		}
		Start ();
	}
	IEnumerator PingPongXAxis(){
		spawnLocation.x = xValue;
	

		for(float f = 0; f < 2f ; f += Time.deltaTime){
			spawnLocation.y = Mathf.PingPong((Time.time*offset)-yValue, yValue);
			spawnLocation.y -= yValue;
			Instantiate(enemys[3], spawnLocation, Quaternion.Euler(0,0,90));	

			spawnLocation.y = Mathf.PingPong((Time.time*offset), yValue);
			Instantiate(enemys[3], spawnLocation, Quaternion.Euler(0,0,90));
			yield return new WaitForSeconds(spawnRate);
		}	
		Start ();
	}
}