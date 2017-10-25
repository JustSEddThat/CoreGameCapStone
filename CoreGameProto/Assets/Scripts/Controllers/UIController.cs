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

		showZeroMessage();

	}
	
	
	void Update () 
    {
		
	}

    public void showKeyAlert()
    {
        
        alert.text = "You've picked up a key!";
        StartCoroutine(AlertWaitGone(1));
        //showFirstMessage();
    }

    IEnumerator waitForClick(string[] textList)
    {

        int index = 0;
        message.text = textList[index];
        index++;

		while (!Input.GetKeyDown(KeyCode.Space))
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
        
        yield return new WaitForEndOfFrame();
		while (!Input.GetKeyDown(KeyCode.Space))
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

	public void showZeroMessage()
	{
		string[] Dialogue = new string[]
			{"Damn you father. I'm going to put an end to your regime, and stop you once and for all.", "Let’s start with dismantling your weapons.", "Ugh, I hate to say it, but I guess I am going to have to find that key first.",
			"If my memory is correct, dad said destroying the targets reveals the key location." };
		GameController.gc.state = GameStates.TextState;
		textPanel.SetActive(true);
		StartCoroutine(waitForClick(Dialogue));


	}

    public void showFirstMessage()
    {
        string[] Dialogue = new string[]
            { "This should be it, lets see, back to the gate?" };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
        GameController.gc.levelChange();

       
    }

    public void showSecondMessage()
    {
        string[] Dialogue = new string[]
            {"Now where do I insert this...", "???", "Strange there's nothing but a guard.", "How bout I reboot you and look some place else."};
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
    }

    public void showThirdMessage()
    {
        string[] Dialogue = new string[]
            {"Here's the second key...", "No entrances around here. I'll check east of here." };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
        GameController.gc.levelChange();
    }

    public void showForThirMessage()
    {
        string[] Dialogue = new string[]
            {"This must be the secret entrance to my father's base of operations" };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
       

    }

    public void showFourthMessage()
    {
        string[] Dialogue = new string[]
            {"The third key.", "This was too easy, I have a bad feeling about this" };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));
        GameController.gc.levelChange();

    }

    public void showFatherMessage()
    {
        string[] Dialogue = new string[]
            {"Father!" };
        GameController.gc.state = GameStates.TextState;
        textPanel.SetActive(true);
        StartCoroutine(waitForClick(Dialogue));


    }
 

    IEnumerator AlertWaitGone(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        alert.text = "";

    }

}
