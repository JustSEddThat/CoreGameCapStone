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

        int index = 0;
        message.text = textList[index];
        index++;

        while (!Input.GetKeyDown(KeyCode.P))
            yield return null;

        if (index < textList.Length)
        {
            message.text = textList[index];
            index++;
            StartCoroutine(waitForClick(textList, index));
        }
        else
        {    
            textPanel.SetActive(false);
            GameController.gc.state = GameStates.PlayState;

        }
            

    }

    IEnumerator waitForClick(string[] textList, int index)
    {
        Debug.Log("yerr");
        yield return new WaitForEndOfFrame();
        while (!Input.GetKeyDown(KeyCode.P))
            yield return null;

        if (index < textList.Length)
        {
            message.text = textList[index];
            index++;
            StartCoroutine(waitForClick(textList, index));

        }
        else
        {    
            textPanel.SetActive(false);
            GameController.gc.state = GameStates.PlayState;

        }

    }

    public void showFirstMessage()
    {
        string[] Dialogue = new string[]
            { "Alright so I have this key. Are there more? Maybe I'll only need this one... Back to the gate." };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
        GameController.gc.levelChange();

       
    }

    public void showSecondMessage()
    {
        string[] Dialogue = new string[]
            { "Now where do I insert this...", "???", "suspicious. Lets go along with this." };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
    }

    IEnumerator AlertWaitGone(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        alert.text = "";

    }

}
