using UnityEngine;
using System.Collections;

public class InstaniateOnDestroy : MonoBehaviour 
{
	public GameObject thing;

	void OnTriggerEnter2D()
	{
		Instantiate(thing, transform.position  , Quaternion.identity);
	}
}
