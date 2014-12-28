using UnityEngine;
using System.Collections;

public class EnemySpawningSystem : MonoBehaviour {

	public GameObject[] enemys;
	public string[] corutines;
	public float spawnRate = 0.1f;

	float xValue;
	float yValue;
	float offset = 1f;
	Vector2 spawnLocation;

	void Start(){
		StartCoroutine (corutines[Random.Range(0,corutines.Length-1)]);
	}
	IEnumerator Box (){

		yValue = Camera.main.orthographicSize;
		xValue = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		spawnLocation.y = yValue;

		StartCoroutine (XLine(1) );
		yield return new WaitForSeconds (spawnRate*(xValueMax /spawnRate)/offset);
		StartCoroutine (YLine(1) );
		yield return new WaitForSeconds (spawnRate*(yValue /spawnRate));
		StartCoroutine (XLine(-1) );
		yield return new WaitForSeconds (spawnRate*(xValueMax /spawnRate)/offset);
		StartCoroutine (YLine(-1) );
		yield return new WaitForSeconds (spawnRate*(-yValue /spawnRate)/offset);

		Start ();
	}
	IEnumerator SickSack(){

		yValue = Camera.main.orthographicSize;
		xValue = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		spawnLocation.y = yValue;

		StartCoroutine (XLine(1) );
		yield return new WaitForSeconds (spawnRate*(xValueMax /spawnRate));
		StartCoroutine (XLine(-1) );
		yield return new WaitForSeconds (spawnRate*(xValueMax /spawnRate));
		StartCoroutine (XLine(1) );
		yield return new WaitForSeconds (spawnRate*(xValueMax /spawnRate));
		StartCoroutine (XLine(-1) );
		yield return new WaitForSeconds (spawnRate*(xValueMax /spawnRate));

		Start ();
	}
	IEnumerator XLine( float posOrNeg ){
		float xValueMax = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
		xValue = -xValueMax * posOrNeg;
		for(float f = 0; f < (xValueMax/offset)*2 ;f++ ){
			spawnLocation.x = xValue;
			Instantiate(enemys[0], spawnLocation, Quaternion.Euler(0,0,90 * (1 + posOrNeg) ));
			Debug.Log (spawnLocation);
			xValue += offset *posOrNeg;
			yield return new WaitForSeconds(spawnRate);
		}
	}
	IEnumerator YLine( float posOrNeg ){
		float yValueMax = Camera.main.orthographicSize * 2;

		for(float f = 0; f < (yValueMax/offset) ;f++ ){
			spawnLocation.y = yValue;
			Instantiate(enemys[0], spawnLocation, Quaternion.Euler(0,0,90* posOrNeg));
			Debug.Log (spawnLocation);
			yValue -= offset * posOrNeg;
			yield return new WaitForSeconds(spawnRate);
		}
	}
}
