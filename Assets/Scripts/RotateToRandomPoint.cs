using UnityEngine;
using System.Collections;

public class RotateToRandomPoint : MonoBehaviour {

	public float rotSpeed = 180f;
	Vector3 randomPos;
	bool posfound = false;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Fynnur random stað til að fara a
		if (!posfound) {
				float screenRatio = (float)Screen.width / (float)Screen.height;
				float posX = Random.Range (-screenRatio * Camera.main.orthographicSize, screenRatio * Camera.main.orthographicSize);
				float posY = Random.Range (-Camera.main.orthographicSize, Camera.main.orthographicSize);
				randomPos = new Vector3 (posX, posY, 0);
				posfound = true;
			}

		//snyr ser að random staðnum
		Vector3 dir = (randomPos - transform.position);
		dir.Normalize ();
		
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		
		Quaternion desierdRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desierdRot, rotSpeed * Time.deltaTime); 


		if ((int)transform.position.x == (int)randomPos.x || (int)transform.position.y == (int)randomPos.y ) {
			posfound = false;
		}
	}
}
