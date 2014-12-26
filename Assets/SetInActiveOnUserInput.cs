using UnityEngine;
using System.Collections;

public class SetInActiveOnUserInput : MonoBehaviour {
	float time = 1f;
	public bool onlyOnce = true;

	void Start(){
		if (PlayerPrefs.GetInt ("FirstTime") == 1) {
			onlyOnce = false;		
		}
		gameObject.SetActive (onlyOnce);
	}

	void Update () {
		if ( 	Input.GetKey(KeyCode.A) ||
		   		Input.GetKey(KeyCode.W) ||
		    	Input.GetKey(KeyCode.S) ||
		    	Input.GetKey(KeyCode.D) ||
		    	Input.GetKey(KeyCode.Space) ||
		    	Input.GetKey(KeyCode.LeftArrow) ||
		    	Input.GetKey(KeyCode.DownArrow) ||
		 	   	Input.GetKey(KeyCode.UpArrow) ||
		  	  	Input.GetKey(KeyCode.RightArrow) ||
		  	  	Input.GetKey(KeyCode.Mouse0)    ) {

			Invoke("SetInactive", time);
		}
	}
	void SetInactive(){
		onlyOnce = false;
		PlayerPrefs.SetInt("FirstTime", 1);
		gameObject.SetActive (onlyOnce);
	}
}
