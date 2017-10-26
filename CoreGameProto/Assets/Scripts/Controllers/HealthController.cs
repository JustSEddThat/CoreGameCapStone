using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour 
{
	public Sprite health, health2, health3;
	private Sprite curHealth;
	private Animator anim;
	public static HealthController hc;

	void Start () 
	{
		hc = this;
		anim = transform.parent.GetComponent<Animator> ();
	}
	

	void Update () 
	{
		
	}

	public void ShowHealth(int number)
	{
		if (number == 3) 
			curHealth = health;
		if (number == 2)
			curHealth = health2;
		if (number == 1)
			curHealth = health3;

		GetComponent<Image> ().sprite = curHealth;
		anim.SetTrigger ("Hurt");
	}
}
