using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    Vector3 initial;
    Rigidbody2D rb;
    public float life = 7;
	public bool alive = true, held = true;
    public bool rightFace;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        rightFace = transform.parent.parent.GetComponent<PlayerScript>().facingRight;
        if (!rightFace)
            transform.Rotate(new Vector3(0, 180, 0));
        initial = transform.position;

		StartCoroutine(Held());
        //StartCoroutine(Fired());
        //StartCoroutine(live());
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

	public void Fire()
	{
		
		held = false;
		StartCoroutine(Fired());
		StartCoroutine(live());
	}

	IEnumerator Held()
	{
		while (held) 
		{
			transform.position = new Vector2 (transform.parent.position.x, transform.parent.position.y);
			yield return null;
		}
	}
    IEnumerator Fired()
    {
		rightFace = transform.parent.parent.GetComponent<PlayerScript>().facingRight;
		transform.parent = null;

        while (alive) 
        {
            if (rightFace)
                rb.velocity = new Vector2(15f, 0);
            else
                rb.velocity = new Vector2(-15f, 0);
            
            yield return null;
        }

        
       Destroy(gameObject);
    }

    IEnumerator live()
    {
        yield return new WaitForSeconds(life);
        alive = false;
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D marked)
    {
        if (marked.gameObject.CompareTag("Bounceable"))
            Destroy(gameObject);

        if (marked.gameObject.CompareTag("Wall"))
        {
            StopCoroutine(Fired());
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
           
        }

        if (marked.gameObject.CompareTag("Enemy"))
            Destroy(gameObject);

    
    }
}
