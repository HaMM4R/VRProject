using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System.Linq;

public class NavAgent : MonoBehaviour
{
    public List<Transform> navPoints = new List<Transform>();
    public NavMeshAgent navAgent;
    public int curWaypoint = 0;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(navPoints[curWaypoint].position);
    }

    void Update()
    {
        FindWaypoint(); 
    }


    public void FindWaypoint()
    {
        if(navAgent.remainingDistance < 2f)
        {
            curWaypoint++;

            if (curWaypoint == navPoints.Count)
                curWaypoint = 0;

            navAgent.SetDestination(navPoints[curWaypoint].position);
        }
    }
}
