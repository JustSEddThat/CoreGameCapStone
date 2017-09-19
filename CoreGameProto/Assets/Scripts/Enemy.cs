using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable 
{
   

	void Start () 
    {
        health = 3;
        secondsTilDeath = 2.5f;
	}
	
	
	void Update () 
    {
        if (health == 0)
            StartCoroutine(waitTilDeath());
	}



    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

}
