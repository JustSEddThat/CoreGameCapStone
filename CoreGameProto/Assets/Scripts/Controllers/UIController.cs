using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
    public Text alert, hub;
    public GameObject textPanel;
    Text message;
    public static UIController uic;

    void Awake()
    {
        uic = this;
    }

	void Start () 
    {
        
        message = textPanel.GetComponentInChildren<Text>();
        textPanel.SetActive(false);
	}
	
	
	void Update () 
    {
		
	}

    public void showKeyAlert()
    {
        
        alert.text = "You've picked up a key!";
        StartCoroutine(AlertWaitGone(1));
        showFirstMessage();
    }

    IEnumerator waitForClick(string[] textList)
    {
        message.text = textList[0];
        if (textList.Length > 1)
        {
          //  string[] list = 
            while (!Input.GetKeyDown(KeyCode.P))
                yield return null;


        }
        textPanel.SetActive(false);
        GameController.gc.state = GameStates.PlayState;


            
    }

    public void showFirstMessage()
    {
        string[] Dialogue = new string[]
            { "Alright so I have this key. Are there more? Maybe, I'll only need this one... Back to the gate." };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        //message.text = "Alright so I have this key. Are there more? Maybe, I'll only need this one... Back to the gate.";
        StartCoroutine(waitForClick(Dialogue));

       
    }

    IEnumerator AlertWaitGone(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        alert.text = "";

    }

}
