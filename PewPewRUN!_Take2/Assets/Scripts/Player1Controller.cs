using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour 
{

	//Movement
	public float LeftRight;
	public float Jump;
	public float wallJumpPower;
	public float wallJumpSpeed;
	//public Vector2 wallJumpOff;
	//private float wallJumpCounter;
	//public float wallJumpCountMax;
	//private bool wallJumped;
	public float movement;
	//Grounded
	public bool Grounded = true;

	private Rigidbody2D rb;
	private Animator anim;

	public Transform groundChecker;
	public float GCheckRad;
	public LayerMask ground;

	public Transform wallChecker;
	public float WCheckRad;

	public bool walled;

	private LevelManager levelManager;
	public int health;
	public int maxHealth;
	public GameObject healthNumText;
	private Text text;

	public float MaxSpeed;
	public float dir;

	public float airControl;


	void Start () 
	{
		text = healthNumText.GetComponent<Text> ();
		health = maxHealth;
		levelManager = FindObjectOfType<LevelManager> ();
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate () {
		// Ground & Wall Check
		//----------------------------------------------------------------------------------------------
		Grounded = Physics2D.OverlapCircle (groundChecker.position, GCheckRad, ground);
		walled = Physics2D.OverlapCircle (wallChecker.position, WCheckRad, ground);

		if (walled) 
		{
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
			{
				walled = true;
			} else {
				walled = false;
			}
		}
	}



	void Update () 
	{
		//Movement
		//--------------------------------------------------------------------------------

		if (walled) {
			movement = 0;
		}
		if (!walled) {
			if (Grounded) {
				movement = 0;
				SetSpeed (0);
				if (Input.GetKey (KeyCode.A)) {
					movement = -LeftRight;
				}
				if (Input.GetKey (KeyCode.D)) {
					movement = LeftRight;
				}
			} else {
				if (Input.GetKey (KeyCode.A)) {
					movement = -airControl;
				}
				if (Input.GetKey (KeyCode.D)) {
					movement = airControl;
				}
			
			}
		}


		//moving Left, Right
		rb.velocity = new Vector2(movement + rb.velocity.x, rb.velocity.y);

		if (Mathf.Abs(rb.velocity.x) > MaxSpeed) {
			rb.velocity = new Vector2(MaxSpeed * (transform.localScale.x/2), rb.velocity.y);
		}


		anim.SetBool ("GROUND", Grounded);
		anim.SetBool ("Walled", walled);
		anim.SetFloat("SPEED", Mathf.Abs (rb.velocity.x));




		//Flipping
		//---------------------------------------------------------------------------------
		if (rb.velocity.x > 0.1)
		{
			transform.localScale = new Vector3(2, 2, 2);
		}
		if (rb.velocity.x < -0.1)
		{
			transform.localScale = new Vector3(-2, 2, 2);
		}
		//Health
		//--------------------------------------------------------
		if (health <= 0) {
			health = 0;
			levelManager.KillPlayer();
		}
		text.text = "" + health;
		//Wall Jump & Jump
		//---------------------------------------------------------------------
		if (wallJumpPower < 0) {
			wallJumpPower = -wallJumpPower;
		}
		if (transform.localScale.x > 0) 
		{
			wallJumpPower = -wallJumpPower;
		}
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(walled)
			{
				WallJump();
			}
			else if (Grounded)
			{
				JumpFunc();
			}
		}
		//if (wallJumped) {
		//	if(wallJumpCounter <= 0)
		//	{
		//		wallJumped = false;
		//	} else {
		//		wallJumpCounter -= Time.deltaTime;
		//		WallJump();
		//	}
		//}
	}

	void WallJump()
	{
		SetSpeed (wallJumpSpeed * (transform.localScale.x/2));
		JumpFunc ();

	}
	void JumpFunc()
	{
		rb.velocity =  new Vector2 (rb.velocity.x, Jump);
	}
	void SetSpeed(float speed)
	{
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

}
