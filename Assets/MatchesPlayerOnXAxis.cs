using UnityEngine;
using System.Collections;

public class MatchesPlayerOnXAxis : MonoBehaviour {
	public float maxSpeed =3f;

	GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");	
		}
		float playerX = player.transform.position.x;
		float pos;
		pos = Mathf.Lerp (transform.position.x, playerX, Time.deltaTime * (maxSpeed/10f));
		transform.position = new Vector2 (pos, 4f);
	}
}
