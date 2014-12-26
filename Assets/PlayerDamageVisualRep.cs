using UnityEngine;
using System.Collections;

public class PlayerDamageVisualRep : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	public Sprite[] damageSprites;
	damageHandler damage;
	int healtCatcher;
	int spriteIndex = 0;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		damage = GetComponentInParent<damageHandler> ();
		healtCatcher = damage.health;
	}
	
	// Update is called once per frame
	void Update () {
		if (damage.health != healtCatcher) {
			spriteRenderer.sprite = damageSprites[spriteIndex];
			spriteIndex++;
			healtCatcher--;
			if(spriteIndex > damageSprites.Length){
				spriteRenderer.sprite = damageSprites[damageSprites.Length-1];
			}
		}
		
	}
}
