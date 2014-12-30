using UnityEngine;
using System.Collections;

public class MoveToRandomPoint : MonoBehaviour {

	Vector3 randomPos;
	float speed = 0.3f;
	bool posfound = false;
	float offset = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!posfound) {
			float screenRatio = (float)Screen.width / (float)Screen.height;
			float posX = Random.Range (-screenRatio * Camera.main.orthographicSize + offset, screenRatio * Camera.main.orthographicSize - offset);
			float posY = Random.Range (-Camera.main.orthographicSize + offset, Camera.main.orthographicSize - offset);
			randomPos = new Vector3 (posX, posY, 0);
			posfound = true;
		}
		transform.Translate (randomPos * Time.deltaTime * speed);

		if ((int)transform.position.x == (int)randomPos.x || (int)transform.position.y == (int)randomPos.y ) {
			posfound = false;
		}

	}
}
