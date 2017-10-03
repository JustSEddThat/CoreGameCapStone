using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public static GameController gc;
    public GameObject a1Trig, a1Gate, firstEnemy;
    public GameStates state;
    [SerializeField]
    int level;

    void OnAwake()
    {
       
    }

	void Start () 
    {
        level = 0;
        a1Trig.SetActive(false);
        firstEnemy.SetActive(false);
        gc = this;
        state = GameStates.PlayState;
	}
	
    public void levelChange()
    {
        level += 1;

        switch (level)
        {
            case 1:
                a1Trig.SetActive(true);
                firstEnemy.SetActive(true);
                break;//
        }
    }

	void Update () 
    {
		
	}

    public void KillGate()
    {
        StartCoroutine(waitSecs());
    }

    IEnumerator waitSecs()
    {
        yield return new WaitForSecondsRealtime(1.7f);
        Destroy(a1Gate);
    }

    public void TriggerFirstKey()
    {
        
    }
}
