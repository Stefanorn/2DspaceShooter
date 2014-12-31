using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealtBarScaler : MonoBehaviour {

	public Image healthBar;
	damageHandler damage;
	float initialHealth;

	// Use this for initialization
	void Start () {
		damage = GetComponent<damageHandler> ();
		initialHealth = (float)damage.health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (damage.health / initialHealth);
		healthBar.fillAmount = damage.health / initialHealth;
	}
}
