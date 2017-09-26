using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounceable : MonoBehaviour 
{
    public GameObject highlighter;
	// Use this for initialization
	void Start () 
    {
        highlighter.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}


    IEnumerator BounceOpportunity(GameObject bouncer)
    {
        highlighter.SetActive(true);
        bouncer.transform.parent.SendMessage("canJump", true);
        yield return new WaitForSeconds(1.3f);
        highlighter.SetActive(false);
        bouncer.transform.parent.SendMessage("canJump", false);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Feet"))
            StartCoroutine(BounceOpportunity(other.gameObject));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Feet"))
        {
            StopCoroutine("BounceOpportunity");
            highlighter.SetActive(false);
        }
    }
}
