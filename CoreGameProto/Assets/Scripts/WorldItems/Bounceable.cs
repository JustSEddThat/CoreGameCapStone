using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounceable : MonoBehaviour 
{
    public GameObject highlighter;
	private float normJump, bestJump;
	// Use this for initialization
	void Start () 
    {
        highlighter.SetActive(false);
		normJump = 300f;
		bestJump = 500f;

	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

	void PullPlayer(GameObject player)
	{
		
	}


    IEnumerator BounceOpportunity(GameObject bouncer)
    {
        highlighter.SetActive(true);
        bouncer.SendMessage("canJump", true);
        yield return new WaitForSeconds(1.7f);
        highlighter.SetActive(false);
        bouncer.SendMessage("canJump", false);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag ("Player")) 
		{
			other.SendMessage ("ChangeJump", bestJump);
			StartCoroutine(BounceOpportunity(other.gameObject));

		}
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
			other.SendMessage ("ChangeJump", normJump);
            StopCoroutine("BounceOpportunity");
            highlighter.SetActive(false);
        }
    }
}
