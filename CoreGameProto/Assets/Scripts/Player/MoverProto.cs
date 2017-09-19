using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverProto : MonoBehaviour 
{
    private Rigidbody2D rb;
    public float speed = 4f;
    public bool facingRight = true;
    public float jumpPower = 300;
    [SerializeField]
    private bool jumpable = false;
	// Use this for initialization
	void Start () 
    {
      
      rb = GetComponent<Rigidbody2D>();
     
	}
	
	// Update is called once per frame
	void Update () 
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jumpable)
            listenForJump();

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

    void canJump(bool canI)
    {
        jumpable = canI;
    }

    void listenForJump()
    {
        if (jumpPower == 500)
            rb.velocity = new Vector2(rb.velocity.x, 0);
       rb.AddForce(new Vector2(0, jumpPower));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
            jumpPower = 500;

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
            jumpPower = 300;
    }


}
