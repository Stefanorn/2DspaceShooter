using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void Play(){
		Application.LoadLevel("Level1");
		}
	void DestroyThings(){
		GameObject[] things;
		things = GameObject.FindGameObjectsWithTag("enemy");
		foreach(GameObject thing in things){
			thing.GetComponent<damageHandler>().Kill();
		}
		things = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject thing in things){
			thing.GetComponent<damageHandler>().Kill();
		}
	}
	public void LevelHandler(string lvl){
		Application.LoadLevel (lvl);
	}
	public void QuitGame (){

		Application.Quit();

	}
	public void ResetThisLevel(){
		PlayerPrefs.SetInt ("FirstTime", 0);
		Application.LoadLevel (Application.loadedLevel);
	}
}
