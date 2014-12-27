using UnityEngine;
using System.Collections;

public class AnimationPlayer : MonoBehaviour {

	void OnTriggerEnter2D(){
		gameObject.GetComponent<Animator> ().SetTrigger ("DamageTaken");
	}
}
