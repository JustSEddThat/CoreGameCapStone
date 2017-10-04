using System.Collections;
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
    private bool jumpable = false;

	public AudioClip jumping;
	public AudioClip step;
	private AudioSource aud;
	
	void Start () 
    {
//Updated upstream
        

        facingRight = true;
// Stashed changes
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
                canJump(true);


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

    void Jump()
    {
        if (jumpPower == 500)
            rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpPower));
		anim.SetBool("Jumping", true);
		aud.clip = jumping;
		aud.PlayOneShot(jumping, 1.0f);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bounceable"))
        {
            jumpPower = 500;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Bounceable"))
            jumpPower = 300;
    }
}
