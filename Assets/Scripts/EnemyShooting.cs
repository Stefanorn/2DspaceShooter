using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireDelay = 0.25f;
	public int range = 4;

	Transform player;

	int bulletLayer;
	float cooldownTimer = 0;
	// Use this for initialization
	void Start () {
		bulletLayer = gameObject.layer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null) {
			GameObject go = GameObject.FindGameObjectWithTag ("Player");
			if (go != null) {
				player = go.transform;		
			}
			Debug.Log("penis");
		}
		if(cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position , player.position) < range) {
			
			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * new Vector3(0,0.5f,0);
			
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset , transform.rotation);
			bulletGO.layer = bulletLayer;
		}
		
		cooldownTimer -= Time.deltaTime;
	}
}
