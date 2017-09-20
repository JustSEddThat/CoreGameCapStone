using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour 
{
    Collider2D cd;
	// Use this for initialization
	void Start () 
    {
        cd = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!cd.IsTouchingLayers()) //1<<8
            transform.parent.SendMessage("canJump", false);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Jumpable") || other.CompareTag("Bounceable"))
            transform.parent.SendMessage("canJump", true);
    }



   
}
