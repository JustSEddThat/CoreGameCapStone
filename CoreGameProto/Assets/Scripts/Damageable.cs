using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour 
{
    [SerializeField]
    protected float health;
    protected float secondsTilDeath;
   

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            health -= 1f;
            if(health <=0)
                StartCoroutine(waitTilDeath(secondsTilDeath, other.gameObject));

        }
    }

    public virtual IEnumerator waitTilDeath(float lag)
    {
        yield return new WaitForSeconds(lag);

        Destroy(gameObject);
    }

    public virtual IEnumerator waitTilDeath(float lag, GameObject other)
    {
        yield return new WaitForSeconds(lag);
        Destroy(other);
        Destroy(gameObject);
    }

    public virtual IEnumerator waitTilDeath()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

}
