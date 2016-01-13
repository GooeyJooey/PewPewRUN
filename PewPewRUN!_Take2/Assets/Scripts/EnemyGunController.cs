using UnityEngine;
using System.Collections;

public class EnemyGunController : MonoBehaviour {
	
	public float shotDelay;
	private float shotDelayCounter;
	public GameObject gun;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		shotDelayCounter = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {

		if (shotDelayCounter <= 0)
		{
			Instantiate(bullet, gun.transform.position, gun.transform.rotation);
			shotDelayCounter = shotDelay;
		} else {
			shotDelayCounter -= Time.deltaTime;
		}
	}
}
