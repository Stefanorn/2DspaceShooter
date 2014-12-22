using UnityEngine;
using System.Collections;

public class damageHandler : MonoBehaviour {

	public int health = 1;
	public bool canGetInvirnable = false;
	public GameObject shield = null;
	float invuln = 0;
	int correctLayer;

	SpriteRenderer spriteRenderer;
	Animator animator;
	ItemDropOnDeath items;

	void Start(){
		correctLayer = gameObject.layer;

		items = gameObject.GetComponent<ItemDropOnDeath> ();

		animator = GetComponent<Animator>();
		if (animator == null) {
			animator = transform.GetComponentInChildren<Animator>();
			if(animator == null){
				//Debug.LogError(gameObject.name + " does not have a sprite Animator");
			}
		}
	}

	void OnTriggerEnter2D( Collider2D col){ 


		if (gameObject.layer != 9 ) {
						if (col.tag == "ShieldUp") {
								GameObject instance = (GameObject)(Instantiate (shield, transform.position, transform.rotation));
								instance.transform.parent = gameObject.transform;
								return;
						}

						if (col.tag == "PowerUp") {
								return;
						}
				}

		if (canGetInvirnable) {
			health--;
			invuln = 0.5f;
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
			if (invuln <= 0) {
				gameObject.layer = correctLayer;
				animator.SetBool("isInvernable", false);
			}
		}
		
		if (health <= 0) {
			Destroy(gameObject);
			items.dead = true;
		}

	}
}
