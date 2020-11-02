using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetManager : MonoBehaviour {
    [Header("Bouncy Target")]
    public int maxBouncyTargetsCount = 2;
    private int curBouncyTargetsCount = 0;
    public Transform bouncyRespPoint;
    public GameObject bouncyTargetPrefab;

    [Header("Heavy Target")]
    public int maxHeavyTargetsCount = 2;
    private int curHeavyTargetsCount = 0;
    public Transform heavyRespPoint;
    public GameObject heavyTargetPrefab;

    [Header("WTF Target")]
    public int maxWTFTargetsCount = 2;
    private int curWTFTargetsCount = 0;
    public Transform wtfRespPoint;
    public GameObject wtfTargetPrefab;
    

    [Header("Walking Target")]
    public Transform walkingTargetResp;
    public Transform[] walkingTargetWaypoints;
    public GameObject walkingTargetPrefab;


    public void InstanciateBouncyTarget()
    {
        if(curBouncyTargetsCount < maxBouncyTargetsCount)
        {
            Instantiate(bouncyTargetPrefab, bouncyRespPoint.position, bouncyRespPoint.rotation);
            curBouncyTargetsCount++;
        }
    }

    public void InstanciateHeavyTarget()
    {
        if (curHeavyTargetsCount < maxHeavyTargetsCount)
        {
            Instantiate(heavyTargetPrefab, heavyRespPoint.position, heavyRespPoint.rotation);
            curHeavyTargetsCount++;
        }
    }

    public void InstanciateWTFTarget()
    {
        if (curWTFTargetsCount < maxWTFTargetsCount)
        {
            Instantiate(wtfTargetPrefab, wtfRespPoint.position, wtfRespPoint.rotation);
            curWTFTargetsCount++;
        }
    }

    public void InstantiateWalkingTarget()
    {
        GameObject walkingTarget = Instantiate(walkingTargetPrefab, walkingTargetResp.position, walkingTargetResp.rotation);
        walkingTarget.GetComponent<WalkingTarget>().Init(walkingTargetWaypoints);
    }
}
