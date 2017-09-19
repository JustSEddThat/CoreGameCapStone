using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour 
{
    public GameObject Shot;
    public bool ready = true;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyUp(KeyCode.F) && ready)
        {
            
            Instantiate(Shot, transform.position, Shot.transform.rotation, transform);
            ready = false;
            StartCoroutine(shotCoolDown());
        }
                
	}


    IEnumerator shotCoolDown()
    {
        yield return new WaitForSeconds(.7f);
        ready = true;
    }


}
