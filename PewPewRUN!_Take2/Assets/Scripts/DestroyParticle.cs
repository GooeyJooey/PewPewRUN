using UnityEngine;
using System.Collections;

public class DestroyParticle : MonoBehaviour {

	private ParticleSystem particles;
	// Use this for initialization
	void Start () {
		particles = GetComponent<ParticleSystem> ();
		//particles.
	}
	
	// Update is called once per frame
	void Update () {
		if (particles.isPlaying)
			return;
		Destroy (gameObject);
	}
}
