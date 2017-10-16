using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour 
{
   
    public bool isGrounded;
    Collider2D cd;
	// Use this for initialization
	void Start () 
    {
        cd = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
       /* if (!cd.IsTouchingLayers(LayerMask.GetMask(new string[]{"Floors", "Springs"})))
            transform.parent.SendMessage("canJump", false);
       */ 
        if (cd.IsTouchingLayers(1 << 8))
            isGrounded = true;
        else
            isGrounded = false;
            
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.CompareTag("Jumpable") || other.CompareTag("Bounceable"))
          //  transform.parent.SendMessage("canJump", true);
    }



   
}
