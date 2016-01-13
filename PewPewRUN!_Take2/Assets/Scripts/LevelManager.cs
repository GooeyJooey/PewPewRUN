using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {



	private Player1Controller player;
	public GameObject respawnParticle;
	public GameObject deathParticle;
	public float respawnDelay;
	private Animator anim;
	private CameraController cam;
	public GameObject spawn;
	public Collider2D playerCollider;
	public GameObject playerObj;
	private GunManager gun;

	// Use this for initialization
	void Start () {
	
		player = FindObjectOfType<Player1Controller> ();
		anim = FindObjectOfType<Animator> ();
		cam = FindObjectOfType<CameraController> ();
		playerCollider = playerObj.GetComponent<Collider2D> ();
		gun = FindObjectOfType<GunManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void KillPlayer()
	{
		StartCoroutine("KillPlayerCo");
	}

	public IEnumerator KillPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		anim.SetBool ("Dead", true);
		player.enabled = false;
		cam.following = false;
		gun.enabled = false;
		playerCollider.enabled = false;
		yield return new WaitForSeconds(respawnDelay);
		player.transform.position = spawn.transform.position;
		player.Grounded = true;
		anim.SetBool ("Dead", false);
		player.enabled = true;
		cam.following = true;
		gun.enabled = true;
		playerCollider.enabled = true;
		player.health = player.maxHealth;

		Instantiate (respawnParticle, player.transform.position, player.transform.rotation);
		
	}
}
