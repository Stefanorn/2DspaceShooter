using UnityEngine;
using System.Collections;

public class ItemDropOnDeath : MonoBehaviour {

	bool dead = false;
	public GameObject[] items;
	public int dropchance = 10;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dead){
				Instantiate(items[Random.Range(0, items.Length-1)],transform.position,Quaternion.identity);
		}
	
	}
}
