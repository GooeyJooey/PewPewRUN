using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Player1Controller player;
	public bool following;
	public Vector3 offset;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player1Controller> ();
		following = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (following)
			Follow ();
	}

	void Follow () {
		transform.position = new Vector3 (player.transform.position.x + offset.x, player.transform.position.y + offset.y, -100);
	}
}
