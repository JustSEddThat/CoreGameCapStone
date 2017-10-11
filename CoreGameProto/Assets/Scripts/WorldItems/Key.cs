using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    public int keyNum;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.uic.showKeyAlert();
            if (keyNum == 1)
            {
                
                UIController.uic.showFirstMessage();
            }

            if (keyNum == 2)
            {
                UIController.uic.showThirdMessage();
            }

            if (keyNum == 3)
            {
                UIController.uic.showFourthMessage();
            }


            Destroy(gameObject);
        }
    }
}
