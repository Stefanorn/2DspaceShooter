using UnityEngine;
using System.Collections;

public class playerShooting : MonoBehaviour {

	public GameObject[] bulletPrefab;
	public float fireDelay = 0.25f;
	public float bulletIndexAmo = 75.0f;
	public float bIT;

	float cooldownTimer = 0;
	//int bulletLayer;
	int bulletIndex = 0;




	// Use this for initialization
	void Start () {
		//bulletLayer = gameObject.layer;
		bIT = bulletIndexAmo;

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButton("Fire1") && cooldownTimer <= 0) {

			cooldownTimer = fireDelay;
			 
			Vector3 offset = transform.rotation * new Vector3(0,0.5f,0);

			Instantiate(bulletPrefab[bulletIndex], transform.position + offset , transform.rotation);
			//bulletGO.layer = bulletLayer;

			if(bulletIndex >= 1){
				if(bulletIndexAmo <= 0){
					bulletIndex--;
					bulletIndexAmo = bIT;
				}
				Debug.Log(bulletIndexAmo); 
				bulletIndexAmo -= 1;

			}
			           
		}

		cooldownTimer -= Time.deltaTime;
	
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "PowerUp" && bulletIndex < bulletPrefab.Length - 1) {
			bulletIndex++;		
		}
	}
}
