using UnityEngine;
using System.Collections;

public class InstaniateOnDestroy : MonoBehaviour 
{
	public GameObject[] things;

	void OnTriggerEnter2D()
	{
		foreach (GameObject thing in things) {
						Instantiate (thing, transform.position, Quaternion.identity);
				}
	}
}
