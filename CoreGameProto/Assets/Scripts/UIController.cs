using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
    public Text Alert, Hub, Message;
    public static UIController uic;

    void Awake()
    {
        uic = this;
    }

	void Start () 
    {
   
	}
	
	
	void Update () 
    {
		
	}

    public void showKeyAlert()
    {
        Alert.text = "You've picked up a key!";
        StartCoroutine(AlertWaitGone(1));
        showFirstMessage();
    }


    public void showFirstMessage()
    {
        Message.text = "Alright so I have this key. Are there more? Maybe, I'll only need this one... Back to the gate.";
    }

    IEnumerator AlertWaitGone(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Alert.text = "";

    }

}
