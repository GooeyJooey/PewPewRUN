using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public GameObject gun;
	public GameObject particle;
	private Player1Controller player;
	//public float bulletLife;
	//private float bulletLifeCounter;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<Player1Controller> ();

		if (player.transform.localScale.x < 0) {
			speed = -speed;
		
		}
//		bulletLifeCounter = bulletLife;
	}
	

	void Update () {
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D col){
		//bulletLifeCounter -= Time.deltaTime;

		//if (bulletLife <= 0) 
		//{
		//	Instantiate (particle, transform.position, transform.rotation);
		//	Destroy (gameObject);
		//}

		if (col.tag == "Bullet")
			return;
		Instantiate (particle, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
