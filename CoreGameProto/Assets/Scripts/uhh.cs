using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uhh : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        UIController.uic.alert.text = "This section is not ready. Gomennasai.";
    }
	
}
