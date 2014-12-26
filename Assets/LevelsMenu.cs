using UnityEngine;
using System.Collections;

public class LevelsMenu : MonoBehaviour {

	public void LevelHandler(string lvl){
		Application.LoadLevel (lvl);
	}
}
