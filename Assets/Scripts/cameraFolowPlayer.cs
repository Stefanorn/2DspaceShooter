using UnityEngine;
using System.Collections;

public class cameraFolowPlayer : MonoBehaviour {

	public Transform myTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (myTarget != null) {
			Vector3 targetPos = myTarget.position;
			targetPos.z = transform.position.z;
			transform.position = targetPos;
		}
	
	}
}
