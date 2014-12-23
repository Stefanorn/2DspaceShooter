using UnityEngine;
using System.Collections;

public class playerShooting : MonoBehaviour {

	public GameObject[] bulletPrefab;
	public float fireDelay = 0.25f;

	float cooldownTimer = 0;
	//int bulletLayer;
	int bulletIndex = 0;




	// Use this for initialization
	void Start () {
		//bulletLayer = gameObject.layer;


	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Fire1") && cooldownTimer <= 0) {

			cooldownTimer = fireDelay;
			 
			Vector3 offset = transform.rotation * new Vector3(0,0.5f,0);

			Instantiate(bulletPrefab[bulletIndex], transform.position + offset , transform.rotation);
			//bulletGO.layer = bulletLayer;
			           
		}

		cooldownTimer -= Time.deltaTime;
	
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "PowerUp" && bulletIndex < bulletPrefab.Length - 1) {
			bulletIndex++;		
		}
	}
}
