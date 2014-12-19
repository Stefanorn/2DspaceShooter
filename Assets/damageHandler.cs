using UnityEngine;
using System.Collections;

public class damageHandler : MonoBehaviour {

	public int health = 1;
	public bool canGetInvirnable = false;
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
				Debug.LogError(gameObject.name + " does not have a sprite Animator");
			}
		}
	}

	void OnTriggerEnter2D(){ 
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
		}

	}
}
