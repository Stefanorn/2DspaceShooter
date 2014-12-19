using UnityEngine;
using System.Collections;

public class FacesPlayer : MonoBehaviour {

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

		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desierdRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desierdRot, rotSpeed * Time.deltaTime); 
	
	}
}
