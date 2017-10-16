using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    [SerializeField]
    private float jumpPower = 300f;
    [SerializeField]
    private float speed = 9f;
    private Feet feet;

    //track states
    public bool facingRight = true;
    public bool isRunning;



    private int lives;
    private Rigidbody2D rb;
    private Animator anim;


	
	public AudioClip step;
	private AudioSource aud;
	



	void Start () 
    {
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

      
        Time.timeScale = 1;
        Run();
 
        if (feet.isGrounded)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Grounded", true);

            if (Input.GetKeyDown(KeyCode.Space))
                Jump();
        }
        else
            anim.SetBool("Grounded", false);


       
    }

    void TextStateUpdate()
    {
        Time.timeScale = 0;
    }

    void PauseUpdate()
    {
    }

     //Handles movement even in the air, but would have isRunning set to false in that case
    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        //While grounded check if moving/anims
        if (feet.isGrounded) 
            if (rb.velocity.x == 0)
            {
                isRunning = false;
                anim.SetBool("Speed", false);
            }
            else
            {
                isRunning = true;
                anim.SetBool("Speed", true);
            }   

        //Checks direction
        if (facingRight && Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
            transform.Rotate(new Vector3(0, 180, 0));
        }
        else if (!facingRight && Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
            transform.Rotate(new Vector3(0, 180, 0));
        }         
    }
        




   


	//Should be called from sendmessage when overlapping a bounceable object
	public void ChangeJump(float jPow)
	{
		jumpPower = jPow;
	}
    void Jump()
    {
		
		anim.SetBool("Jumping", true);
        anim.SetBool("Grounded", false);
        if (jumpPower == 500)
            rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpPower));	
		//aud.clip = jumping;
		//aud.PlayOneShot(jumping, .5f);


    }


    void OnTriggerEnter2D(Collider2D other)
    {
      
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
