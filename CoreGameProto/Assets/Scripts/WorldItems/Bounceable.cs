using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounceable : MonoBehaviour 
{
    


	// Use this for initialization
	void Start () 
    {
      

	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

	void PullPlayer(GameObject player)
	{
		player.GetComponent<Rigidbody2D> ().velocity /= 2;
	}


    IEnumerator BounceOpportunity(GameObject bouncer)
    {
      
       // bouncer.SendMessage("canJump", true);
        yield return new WaitForSeconds(1.7f);
     
      //  bouncer.SendMessage("canJump", false);
    }

	//public void 
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag ("Player")) 
		{
		//	PullPlayer (other.gameObject);
			//other.SendMessage ("ChangeJump", bestJump);

			transform.GetChild(0).SendMessage("TriggerAnim");
			StartCoroutine(BounceOpportunity(other.gameObject));

		}
            
    }



    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
			//other.SendMessage ("ChangeJump", normJump);

			transform.GetChild(0).SendMessage("ExitAnim");
            StopCoroutine("BounceOpportunity");
           
        }
    }
}
