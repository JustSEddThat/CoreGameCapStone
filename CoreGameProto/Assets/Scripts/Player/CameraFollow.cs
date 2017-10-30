using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	
    private GameObject player;

	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FollowPlayer());
	}
	
	// Update is called once per frame
	void Update () 
    {
       
	}

    IEnumerator FollowPlayer ()
    {
        while (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.835f, -16);
            yield return null;
        }
    }

 
}
