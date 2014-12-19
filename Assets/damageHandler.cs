using UnityEngine;
using System.Collections;

public class damageHandler : MonoBehaviour {

	public int health = 1;
	public bool canGetInvirnable = false;
	float invuln = 0;
	int correctLayer;

	SpriteRenderer spriteRenderer;

	void Start(){
		correctLayer = gameObject.layer;

		spriteRenderer = GetComponent<SpriteRenderer>();
		if (spriteRenderer == null) {
			spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
			if(spriteRenderer == null){
				Debug.LogError(gameObject.name + " does not have a sprite Rendere");
			}
		}
	}

	void OnTriggerEnter2D(){ 
		if (canGetInvirnable) {
			health--;
			invuln = 0.5f;
			gameObject.layer = 10;
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
//				if(spriteRenderer == !null){
//					spriteRenderer.enabled = true;
//				}
//			}
//			else {
//				if(spriteRenderer == !null){
//					spriteRenderer.enabled = !spriteRenderer.enabled;
//				}
			}
		}
		
		if (health <= 0) {
			Destroy(gameObject);		
		}

	}
}
