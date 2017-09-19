using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public static GameController gc;
    public GameStates state;

    void OnAwake()
    {
       
    }

	void Start () 
    {
        gc = this;
        state = GameStates.PlayState;
	}
	

	void Update () 
    {
		
	}


    public void TriggerFirstKey()
    {
        
    }
}
