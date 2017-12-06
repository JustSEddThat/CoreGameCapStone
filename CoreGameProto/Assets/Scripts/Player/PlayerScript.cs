using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerStates{grounded, inAir, jumping, leaping}

public class PlayerScript : MonoBehaviour 
{
	#region variables
	private playerStates playState;
    [SerializeField]
    private float jumpPower = 300f;
    [SerializeField]
    private float speed = 9f;
    private Feet feet;
	private bool canLeap;
	private bool vulnerable;





    //track states
    public bool facingRight = true;
    public bool isRunning;
	public bool isPulled;


    public int lives;
    private Rigidbody2D rb;
    private Animator anim;


	

	private AudioSource aud;
	#endregion variables

	void Start () 
    {
		Physics2D.IgnoreLayerCollision (11, 12);
		isPulled = false;
		playState = playerStates.inAir;
		vulnerable = true;
        feet = transform.GetComponentInChildren<Feet>();
        isRunning = false;
        lives = 3;
        facingRight = true;
        aud = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
		

        if (GameController.gc.state == GameStates.PlayState)
            PlayerStateUpdate();
        if (GameController.gc.state == GameStates.TextState)
            TextStateUpdate();
        if (GameController.gc.state == GameStates.Paused)
            PauseUpdate();    
	}

    void PlayerStateUpdate()
    {

		switch (playState) 
		{
		case playerStates.grounded:
			anim.SetBool ("Grounded", true);
			//anim.SetBool ("Jumping", false);
			if (!feet.isGrounded)
				playState = playerStates.inAir;
			break;

		case playerStates.inAir:
			anim.SetBool ("Grounded", false);
			anim.SetBool ("Moving", false);

			if (feet.isGrounded)
				playState = playerStates.grounded;
			break;

			case playerStates.jumping:
			anim.SetTrigger ("Jump");
			anim.SetBool ("Grounded", false);
			anim.SetBool ("Speed", false);
			break;

		case playerStates.leaping:
			anim.SetTrigger ("Leap");
			//anim.SetBool ("Jumping", false);
			if (feet.isGrounded)
				playState = playerStates.grounded;
			break;
		}


		Time.timeScale = 1;
		if (lives <= 0)
			GameController.gc.respawn ();

        Run();
		RunAudio ();
 
		if (feet.isGrounded) 
		{
			if (Input.GetButtonDown("Jump")) 
				Jump ();
			
		}
		else
			if (canLeap && Input.GetButtonDown("Jump")) 
		{

			Leap ();
			
		}
        
    }

    void TextStateUpdate()
    {
        Time.timeScale = 0;
		aud.Stop ();
    }

    void PauseUpdate()
    {
		
    }

	void RunAudio()
	{
		if (anim.GetBool ("Grounded") && anim.GetBool ("Moving")) 
		{
			if (!aud.isPlaying)
				aud.Play ();
		} 
		else 
		{
			if(aud.isPlaying)
				aud.Stop ();
		}
	}
     //Handles movement even in the air, but would have isRunning set to false in that case
    void Run()
    {

		float h, h2;
		h = Input.GetAxis ("Horizontal");
		h2 = Input.GetAxis ("Horizontal2");

		if (h2 != 0)
			rb.velocity = new Vector2 (h2 * speed, rb.velocity.y);
		else if (h != 0)
			rb.velocity = new Vector2 (h * speed, rb.velocity.y);
		else
			rb.velocity = new Vector2 (0, rb.velocity.y);


        //While grounded check if moving/anims
        if (feet.isGrounded) 
            if (rb.velocity.x == 0)
            {
				
                isRunning = false;
                anim.SetBool("Moving", false);
            }
            else
            {
                isRunning = true;
                anim.SetBool("Moving", true);
            }   

        //Checks direction
		if (facingRight && rb.velocity.x < 0)
        {
            facingRight = false;
            transform.Rotate(new Vector3(0, 180, 0));
		
        }
		else if (!facingRight && rb.velocity.x > 0)
        {
            facingRight = true;
            transform.Rotate(new Vector3(0, 180, 0));
	
        }  


    }
        


    void Jump()
    {
		//rb.velocity = new Vector2 (rb.velocity.x, 0);
		anim.SetTrigger ("Jump");
        rb.AddForce(new Vector2(0, jumpPower)*1.5f);	
		//aud.clip = jumping;
		//aud.PlayOneShot(jumping, .5f);
    }

	void Leap()
	{
		rb.velocity = new Vector2 (rb.velocity.x, 0);
		//anim.SetBool ("Jumpin", false);
		anim.SetTrigger ("Leap");
		rb.AddForce (new Vector2 (0, 500)*1.3f);
	}

	public void Damage(int dealt)
	{
		lives -= dealt;
		HealthController.hc.ShowHealth (lives);
		StartCoroutine (DamageCoolDown ());
	}

	IEnumerator DamageCoolDown()
	{
		vulnerable = false;
		yield return new WaitForSeconds (.5f);
		vulnerable = true;

	}


	public void HoldFire(bool hold)
	{
		
		anim.SetBool ("HoldFire", hold);
	}

	public void Firing()
	{
		anim.SetTrigger ("Firing");
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag ("Bounceable")) 
		{
			
			canLeap = true;
			//jumpPower = 500;
		}
    }

    void OnTriggerExit2D(Collider2D other)
    {
		if (other.CompareTag ("Bounceable")) 
		{
			canLeap = false;
			//jumpPower = 300;
		}
    }
}

