using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pressb : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire3"))
			GoBack ();
	}

	public void GoBack()
	{
		SceneManager.LoadScene ("Title Screen");
	}
}
