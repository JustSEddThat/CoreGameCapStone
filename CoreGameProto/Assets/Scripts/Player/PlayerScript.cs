﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour 
{
    [SerializeField]
    private float jumpPower = 300f;
    [SerializeField]
    private float speed = 9f;


    public bool facingRight = true;
    private Rigidbody2D rb;
    private Animator anim;
    private bool jumpable;

	
	public AudioClip step;
	private AudioSource aud;
	
	void Start () 
    {
		jumpable = false;
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
		if (isMoving())
		{
			anim.SetBool("Speed", true);
		}
		else
			anim.SetBool("Speed", false);



        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jumpable)
            Jump();
        if (Input.GetKeyDown(KeyCode.Space) && !jumpable)
            if (GetComponent<Collider2D>().IsTouchingLayers(1 << 8))
                Jump();


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

    bool isMoving()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            aud.clip = step;
            if(!aud.isPlaying && anim.GetBool("Speed") && anim.GetBool("Grounded") )
			    aud.Play();
            return true;
        }
        return false;
    }

    void isGrounded(bool isTrue)
    {
		anim.SetBool("Grounded", isTrue);
		if(isTrue)
			anim.SetBool("Jumping", false);

    }
    void TextStateUpdate()
    {
        Time.timeScale = 0;
    }

    void PauseUpdate()
    {
    }

    void canJump(bool canI)
    {
        jumpable = canI;
    }

	//Should be called from sendmessage when overlapping a bounceable object
	public void ChangeJump(float jPow)
	{
		jumpPower = jPow;
	}
    void Jump()
    {
		//if (anim.GetBool ("Jumping"))
			//anim.CrossFade("Jumping", 1);
		//else
			anim.SetBool("Jumping", true);
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
