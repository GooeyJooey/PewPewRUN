using UnityEngine;
using System.Collections;

public class GunManager : MonoBehaviour {

	public float shotDelay;
	private float shotDelayCounter;
	public GameObject gun;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
		{
			Instantiate(bullet, gun.transform.position, gun.transform.rotation);
			shotDelayCounter = shotDelay;
		}
		if (Input.GetKey(KeyCode.C))
		{
			if (shotDelayCounter <= 0)
			{
				Instantiate(bullet, gun.transform.position, gun.transform.rotation);
				shotDelayCounter = shotDelay;
			} else {
				shotDelayCounter -= Time.deltaTime;
			}
		}
	}
}
