﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour 
{
    public GameObject Shot;
    public bool ready = true;
	private GameObject arrow;
	private bool held;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (GameController.gc.state == GameStates.PlayState) 
		{
			if (ready) 
			{
				if (Input.GetButtonDown ("Fire1")) 
				{
					transform.parent.SendMessage ("HoldFire", true);
					held = true;
					if (ready)
						arrow = Instantiate (Shot, transform.position, Shot.transform.rotation, transform);  
				}
				else if (Input.GetButtonUp ("Fire1")) 
				{
					transform.parent.SendMessage ("HoldFire", false);
			

					if (ready && arrow != null && held) 
					{
						transform.parent.SendMessage ("Firing");
						arrow.SendMessage ("Fire");
						//Instantiate (Shot, transform.position, Shot.transform.rotation, transform);
						ready = false;
						held = false;
						GetComponent<AudioSource> ().Play ();
						StartCoroutine (shotCoolDown ());
					}
				}
			}
		}
                
	}


    IEnumerator shotCoolDown()
    {
        yield return new WaitForSeconds(.5f);
        ready = true;
    }


}
