using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    Vector3 initial;
    Rigidbody2D rb;
    public float life = 7;
    public bool alive = true;
    public bool rightFace;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        rightFace = transform.parent.GetComponent<PlayerScript>().facingRight;
        if (!rightFace)
            transform.Rotate(new Vector3(0, 180, 0));
        initial = transform.position;
        StartCoroutine(Fired());
        StartCoroutine(live());
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    IEnumerator Fired()
    {
        
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
