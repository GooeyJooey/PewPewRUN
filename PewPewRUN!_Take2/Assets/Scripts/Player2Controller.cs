using UnityEngine;
using System.Collections;

public class Player2Controller : MonoBehaviour 
{

	//Movement
	public float LeftRight;
	public float Jump;
	float movement;
	//Grounded
	bool Grounded = true;

	private Rigidbody2D rb;
	private Animator anim;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}



	void Update () 
	{


		if(Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O))
		{
			if(Grounded)
			{
				rb.velocity = new Vector2(rb.velocity.x, Jump);
			}
		}

		movement = 0;
		//moving Left, Right
		if(Input.GetKey(KeyCode.J))
		{
			movement = -LeftRight;
		}
		if(Input.GetKey(KeyCode.L))
		{
			movement = LeftRight;
		}
		rb.velocity = new Vector2(movement, rb.velocity.y);
		anim.SetBool ("GROUND", Grounded);
		anim.SetFloat("SPEED", Mathf.Abs (rb.velocity.x));
		
		
		if (rb.velocity.x > 0.1)
		{
			transform.localScale = new Vector3(-2, 2, 2);
		}
		if (rb.velocity.x < -0.1)
		{
			transform.localScale = new Vector3(2, 2, 2);
		}
	}

	//Ground Check
	void OnTriggerEnter2D ()
	{
		Grounded = true;
	}
	void OnTriggerExit2D ()
	{
		Grounded = false;
	}
}
