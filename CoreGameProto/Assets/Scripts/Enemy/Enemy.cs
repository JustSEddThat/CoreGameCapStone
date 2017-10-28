using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable 
{

    Rigidbody2D rb;
    bool facingRight;
    public GameObject barrier;
    public bool isMover, damaged;
	private Sprite myImage;
	private SpriteRenderer sr;

	void Start ()
    {

        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        health = 3;
        secondsTilDeath = 2.5f;
		damaged = false;
		myImage = GetComponent<SpriteRenderer> ().sprite;
		sr = GetComponent<SpriteRenderer> ();
	}
	
	
	void Update () 
    {
		if (GameController.gc.state == GameStates.PlayState && isMover && !damaged)
            Movement();
        
        if (health <= 0)
        {
            if(barrier != null)
                Destroy(barrier);
            Destroy(gameObject);
        }
	}

    void Movement()
    {
        if (facingRight)
            rb.velocity = new Vector2(5f, 0);
        else
            rb.velocity = new Vector2(-5f, 0);
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Jumpable") && !coll.gameObject.CompareTag("Arrow"))
            facingRight = !facingRight;
    }

	IEnumerator appearDamaged()
	{
		damaged = true;
		rb.velocity = new Vector2(0,0);
		yield return new WaitForSeconds (4f);
		damaged = false;

			
	}

    public override void OnTriggerEnter2D(Collider2D other)
    {
       
		if (other.CompareTag ("Arrow")) 
		{
			
			health--;
		}
		

		if (other.CompareTag ("Player"))
			other.SendMessage ("Damage", 1);
    }

}
