﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditional : MonoBehaviour 
{
    public List<GameObject> collectOrDestroy;
    public GameObject openOrUnlock;

	// Use this for initialization
	void Start () 
    {
        openOrUnlock.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        foreach (GameObject g in collectOrDestroy)
            if (g == null)
                collectOrDestroy.Remove(g);
        if (collectOrDestroy.Count == 0)
            openOrUnlock.SetActive(true);

        if (openOrUnlock == null)
            Destroy(this);
	}
}
