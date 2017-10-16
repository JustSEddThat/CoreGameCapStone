using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable 
{

    Rigidbody2D rb;
    bool facingRight;
    public GameObject barrier;
    public bool isMover;

	void Start ()
    {

        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        health = 3;
        secondsTilDeath = 2.5f;
	}
	
	
	void Update () 
    {
        if (GameController.gc.state == GameStates.PlayState && isMover)
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

    public override void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Arrow"))
          health--;

		if (other.CompareTag ("Player"))
			other.SendMessage ("Damage", 1);
    }

}
