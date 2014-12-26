using UnityEngine;
using System.Collections;

public class DeathAfterGivenTime : MonoBehaviour {
	public float time = 5.0f;
	// Use this for initialization
	void Start () {
		Invoke ("Die", time);
	}
	
	// Update is called once per frame
	void Die () {
		Destroy (gameObject);
	}
}
