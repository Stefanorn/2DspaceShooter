using UnityEngine;
using System.Collections;

public class damageHandler : MonoBehaviour {

	public int health = 1;
	public bool canGetInvirnable = false;
	public GameObject shield = null;
	public GameObject[] items;
	public float dropchance = 10.0f;
	public GameObject[] deathGameObjects;
	float invuln = 0;
	int correctLayer;

	SpriteRenderer spriteRenderer;
	Animator animator;

	void Start(){

		correctLayer = gameObject.layer;


		animator = GetComponent<Animator>();
		if (animator == null) {
			animator = transform.GetComponentInChildren<Animator>();
			if(animator == null){
				//Debug.LogError(gameObject.name + " does not have a sprite Animator");
			}
		}
	}

	void OnTriggerEnter2D( Collider2D col){ 
//		if (gameObject.layer == 11) {
//			return;		
//		}

		if (gameObject.layer != 9 ) {
			if (col.tag == "ShieldUp" && shield != null) {
								GameObject instance = (GameObject)(Instantiate (shield, transform.position, transform.rotation));
								instance.transform.parent = gameObject.transform;
								return;
						}

				if (col.tag == "PowerUp" || col.tag == "MissileUp") {
								return;
						}
				}

		if (canGetInvirnable) {
			health--;
			invuln = 0.7f;
			gameObject.layer = 10;
			animator.SetBool("isInvernable", true);
		}
		else{
			health--;
		}
	}
	void Update()
	{
		if (invuln > 0) {
			invuln -= Time.deltaTime;
			if (invuln <= 0 && canGetInvirnable) {
				gameObject.layer = correctLayer;
				animator.SetBool("isInvernable", false);
			}
		}
		
		if (health <= 0) 
		{
			if( items.Length != 0 ){
				if(Random.Range(0f,100f) <= dropchance){
					Instantiate(items[Random.Range(0, items.Length)],transform.position,Quaternion.identity);
				}
			}
		Destroy(gameObject);
		InstasiateOnDestroy();
		}

	}
	void InstasiateOnDestroy()
	{
		if (deathGameObjects != null) {
			foreach (GameObject thing in deathGameObjects) {
				Instantiate (thing, transform.position, Quaternion.identity);
			}
		}
	}
	public void Kill(){
		health = 0;
	}
}
