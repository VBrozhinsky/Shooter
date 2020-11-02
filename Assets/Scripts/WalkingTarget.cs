using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingTarget : MonoBehaviour {
    private Transform curDestination;
    private NavMeshAgent navMesh;
    private Transform[] waypoints;

    private int health;
    public GameObject[] healthImages;
    public GameObject destroyedTargetPrefab;


    public void Init(Transform[] _waypoints)
    {
        waypoints = _waypoints;
    }

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        health = healthImages.Length;
        SetRandomNavMeshAgentDestination();
    }

    private void Update()
    {
        float dist = navMesh.remainingDistance;
        if(dist != Mathf.Infinity && navMesh.pathStatus == NavMeshPathStatus.PathComplete && navMesh.remainingDistance < 0.1f)
        {
            SetRandomNavMeshAgentDestination();
        }
    }

    private void SetRandomNavMeshAgentDestination()
    {
        int waypointIndex = Random.Range(0, waypoints.Length);
        curDestination = waypoints[waypointIndex];
        navMesh.SetDestination(curDestination.position);
    }

    public void TakeDamage()
    {
        health--;
        healthImages[health].SetActive(false);
        if(health <= 0)
        {
            Transform currentTransform = transform;
            GameObject go = Instantiate(destroyedTargetPrefab, currentTransform.position, currentTransform.rotation);
            Destroy(gameObject);
            Destroy(go, 5.0f);
        }
    }
}
