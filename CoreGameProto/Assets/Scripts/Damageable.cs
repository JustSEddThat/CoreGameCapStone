using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour 
{
    public float health;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (health == 0)
            StartCoroutine(waitTilDeath());
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            health -= 1f;
        }
    }

    IEnumerator waitTilDeath()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

}
