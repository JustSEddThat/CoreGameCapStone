using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloScript : MonoBehaviour 
{
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void TriggerAnim()
	{
		anim.SetTrigger ("PlayerHover");
	}

	public void ExitAnim()
	{
		anim.SetTrigger ("PlayerExit");
	}
}
