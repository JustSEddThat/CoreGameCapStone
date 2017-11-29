using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable 
{

    Rigidbody2D rb;
    bool facingRight;
	private float width, height;
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
		width = GetComponent<BoxCollider2D> ().size.x;
		height = GetComponent<BoxCollider2D> ().size.y;


	}
	
	
	void Update () 
    {
		if (GameController.gc.state == GameStates.PlayState && isMover && !damaged)
            Movement();

		EnemyHealth ();

        if (health <= 0)
        {
            if(barrier != null)
                Destroy(barrier);
            Destroy(gameObject);
        }
	}


	void EnemyHealth()
	{
		
		transform.GetChild (0).localScale = new Vector3 (2*(health / 3), .2f);
	}
    void Movement()
    {
		
		if (facingRight) 
		{
			rb.velocity = new Vector2 (5f, 0);
			transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		}
		else 
		{
			rb.velocity = new Vector2 (-5f, 0);
			transform.localRotation= Quaternion.Euler(new Vector3(0, 180, 0));
		}
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
