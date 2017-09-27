using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger1 : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIController.uic.showSecondMessage();
            GameController.gc.KillGate();
        }

        Destroy(gameObject);
    }

}
