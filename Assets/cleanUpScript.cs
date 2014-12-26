using UnityEngine;
using System.Collections;

public class cleanUpScript : MonoBehaviour {

	bool hasChild = false;
	// Use this for initialization
	void Start () {
		if (transform.childCount != 0) {
			hasChild = true;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (audio != null) {
						if (!audio.isPlaying) {
								Destroy (gameObject);		
						}
				}
		if (particleSystem != null) {
			if(particleSystem.isStopped){
				Destroy (gameObject);
			}		
		}
		if (hasChild) {
			if(transform.childCount == 0){
				Destroy(gameObject);
			}		
		}
	
	}
	void OnBecameInvisible(){
		Destroy (gameObject);
	}

}
