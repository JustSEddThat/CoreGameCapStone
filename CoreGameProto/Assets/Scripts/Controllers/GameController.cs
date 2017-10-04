using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
    public static GameController gc;
    public GameObject a1Trig, a1Gate, a2Gate, firstEnemy;
    public GameStates state;
    public GameObject player;
    public Vector3 respawnPoint;
    [SerializeField]
    int level;

    void OnAwake()
    {
       
    }

	void Start () 
    {
        level = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPoint = player.transform.position;
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
                break;

            case 2:
                Destroy(a2Gate);
                break;

        }
    }

	void Update () 
    {
		
	}

    public void respawn()
    {
        player.transform.position = respawnPoint;
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
