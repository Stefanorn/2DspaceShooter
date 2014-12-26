using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float	rotationSpeed = 180f;

	float shipBondaryRadius = 0.5f;
	Animator animator; 

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//Ser um að snua skipinu

		//Grab our rotation in Quaternion
		Quaternion rot = transform.rotation;
		//Grab the Z euler
		float z = rot.eulerAngles.z;
		// Change the Z angle based on input
		z -= Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		// Recreate the quaternion
		rot = Quaternion.Euler (0, 0, z);
		//Feet the Quaternin in to the rotation
		transform.rotation = rot;

		//ser um að fara afram
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime ,0);


		pos += rot * velocity;



		if ( Input.GetKey(KeyCode.W) || Input.GetKey( KeyCode.UpArrow ) ) {
						animator.SetBool ("isMoving", true);
				}
		else {
			animator.SetBool ("isMoving", false);
		}

		// RESTRICT Player to the camera bounderis

		//First to Vertical, Becouse it is simple
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

		//update position
		transform.position = pos; 

	}
}
