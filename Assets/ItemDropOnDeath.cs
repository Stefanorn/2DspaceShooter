using UnityEngine;
using System.Collections;

public class ItemDropOnDeath : MonoBehaviour {

	bool dead = false;
	public GameObject[] items;
	public int dropchance = 10;
	damageHandler damage;

	// Use this for initialization
	void Start () 
	{
		damage = gameObject.GetComponent<damageHandler> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dead){
			Debug.Log("damage Fær 0");
				Instantiate(items[Random.Range(0, items.Length-1)],transform.position,Quaternion.identity);
		}
	
	}
}
