using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyLevel {targets, enemies1};
public class TargetController : MonoBehaviour 
{
    public static TargetController tc;
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
}
