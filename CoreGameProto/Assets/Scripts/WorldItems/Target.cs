using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Damageable 
{
    
    public bool red;

	void Start () 
    {
        health = 1;
        secondsTilDeath = 1.5f;
	}
	
	
	void Update () 
    {
        
        if (health == 0)
            StartCoroutine(waitTilDeath(secondsTilDeath));
	}

    public override IEnumerator waitTilDeath(float lag)
    {
        yield return new WaitForSeconds(lag);
        if(red)
            TargetController.tc.destroyedRTarget();
        Destroy(gameObject);
        
    }
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other.CompareTag("Arrow"))
            GetComponentInChildren<ParticleSystem>().Play();
    } 
}
