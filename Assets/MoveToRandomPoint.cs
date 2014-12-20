using UnityEngine;
using System.Collections;

public class MoveToRandomPoint : MonoBehaviour {

	public float rotSpeed = 180f;
	
	Transform player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Player");
			if (go != null) {
				player = go.transform;		
			}
		}
		if (player == null) {
			return;		
		}

		//Fynnur random stað til að fara a
		Vector3 pos;
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float posX = Random.Range (-screenRatio * Camera.main.orthographicSize  , screenRatio * Camera.main.orthographicSize );
		float posY = Random.Range (-Camera.main.orthographicSize, Camera.main.orthographicSize);
		pos = new Vector3 (posX, posY, 0);

		
		Vector3 dir = (player.position - transform.position);
		dir.Normalize ();
		
		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		
		Quaternion desierdRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desierdRot, rotSpeed * Time.deltaTime);

		/*
		if (pos.y + shipBondaryRadius > Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBondaryRadius;
		}
		if (pos.y - shipBondaryRadius < -Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBondaryRadius;		
		}
		// Now calcultae ratio  from heigt to with
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float withOrtho = Camera.main.orthographicSize * screenRatio;
		
		// Now do horizontal bounderys
		if (pos.x + shipBondaryRadius > withOrtho) {
			pos.x = -withOrtho + shipBondaryRadius;
		}
		if (pos.x - shipBondaryRadius < -withOrtho) {
			pos.x = withOrtho - shipBondaryRadius;		
		}
		*/
	}
}
