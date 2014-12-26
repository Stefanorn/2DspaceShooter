using UnityEngine;
using System.Collections;

public class FacesEnemy : MonoBehaviour {

	public float range = 5.0f;
	public float rotSpeed = 180.0f;
	

	void Update()
	{
		GameObject target = null;	
		foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, range)) {
				if (col.tag == "enemy") {
					target = col.gameObject;
					break;
				}
			}
		Debug.Log (target );

		if (target != null) {
						Vector3 dir = (target.transform.position - transform.position);
						dir.Normalize ();

						float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
						Quaternion desierdRot = Quaternion.Euler (0, 0, zAngle);
						transform.rotation = Quaternion.RotateTowards (transform.rotation, desierdRot, rotSpeed * Time.deltaTime); 
				}
	}
}