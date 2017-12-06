using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour 
{

	public void OnPlay()
	{
		SceneManager.LoadScene ("MainScene");
	}

	public void OnOptions()
	{
		
	}

	public void OnControl()
	{
		SceneManager.LoadScene ("Controls");
	}

	public void OnPreface()
	{
		SceneManager.LoadScene ("Preface");
	}

	public void OnTitle()
	{
		SceneManager.LoadScene ("Title Screen");
	}
}
