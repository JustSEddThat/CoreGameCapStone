using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyLevel {targets, enemies1};
public class TargetController : MonoBehaviour 
{
    public static TargetController tc;
    public GameObject key1;
    GameObject[] redTargets;
    [SerializeField]
    float numRTargets;
    float numGTargets;
    GameObject[] greenTargets;

    void Awake()
    {
        tc = this;
    }


	void Start () 
    {
        redTargets = GameObject.FindGameObjectsWithTag("RedTarget");
        numRTargets = redTargets.Length;
        greenTargets = GameObject.FindGameObjectsWithTag("GreenTarget");
        numGTargets = greenTargets.Length;

        foreach (GameObject gt in greenTargets)
            gt.SetActive(false);

        key1.SetActive(false);
        foreach (Transform i in transform)
            ;
	}
	

	void Update () 
    {
        
	}

    public void destroyedRTarget()
    {
        numRTargets--;
        if (numRTargets < 1)
            foreach (GameObject gt in greenTargets)
                gt.gameObject.SetActive(true);
    }

    public void destroyedGTarget()
    {
        key1.SetActive(true);
    }
}
