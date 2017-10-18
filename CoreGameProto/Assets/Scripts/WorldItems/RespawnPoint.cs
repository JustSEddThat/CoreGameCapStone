﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			GameController.gc.respawnPoint = transform.position;
			Destroy (GetComponent<Collider2D> ());
		}
	}
}
