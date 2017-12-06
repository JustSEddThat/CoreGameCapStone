using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTarget : MonoBehaviour 
{
	public GameObject targetPrefab;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (WaitToRespawn ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	IEnumerator WaitToRespawn ()
	{
		while(true)
		{
			yield return new WaitForSeconds (4);
			if (transform.childCount == 0)
				Instantiate (targetPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 180)), transform);
		}
	}
}
