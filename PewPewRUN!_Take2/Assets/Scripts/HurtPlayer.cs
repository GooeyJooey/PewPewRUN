using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	private Player1Controller player;
	public int damage;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player1Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			player.health -= damage;
		}
	}
}
