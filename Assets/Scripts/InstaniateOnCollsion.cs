using UnityEngine;
using System.Collections;

public class InstaniateOnCollsion : MonoBehaviour 
{
	public GameObject[] things;

	void OnTriggerEnter2D()
	{
		foreach (GameObject thing in things) {
						Instantiate (thing, transform.position, Quaternion.identity);
				}
	}
}
