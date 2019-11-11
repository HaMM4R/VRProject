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
        SetupNavPoints();
    }

    void Update()
    {
        FindWaypoint(); 
    }

    public virtual void SetupNavPoints()
    {
        GameObject[] wayPointHolder =  GameObject.FindGameObjectsWithTag("WaypointPerson").OrderBy(go => go.name).ToArray();

        for (int i = 0; i < wayPointHolder.Length; i++)
        {
            navPoints.Add(wayPointHolder[i].transform);
        }

        navAgent.SetDestination(navPoints[curWaypoint].position);
    }

    public void FindWaypoint()
    {
        if ((gameObject.transform.position.x == navPoints[curWaypoint].position.x) && (gameObject.transform.position.z == navPoints[curWaypoint].position.z))
        {
            curWaypoint++;

            if (curWaypoint == navPoints.Count)
                curWaypoint = 0;

            navAgent.SetDestination(navPoints[curWaypoint].position);
        }
    }
}
