using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

	public float delay;
	public float maxDelay;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		delay = maxDelay;
	}
	
	// Update is called once per frame
	void Update () {

		if (delay <= 0) 
		{
			Instantiate (bullet, transform.position, transform.rotation);
			delay = maxDelay;
		} else {
			delay -= Time.deltaTime;
		}
	}
}
