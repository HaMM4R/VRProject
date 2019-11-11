using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianBehaviour : MonoBehaviour
{
    public List<Transform> navPoints = new List<Transform>();
    public NavMeshAgent navAgent;

    [SerializeField]
    Animator anims; 

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        SetupNavPoints(); 

        int destination = Random.Range(0, navPoints.Count);
        navAgent.SetDestination(navPoints[destination].position);
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        AnimationController(); 
    }

    void SetupNavPoints()
    {
        GameObject[] wayPointHolder = GameObject.FindGameObjectsWithTag("WaypointPerson");

        for (int i = 0; i < wayPointHolder.Length; i++)
        {
            navPoints.Add(wayPointHolder[i].transform);
        }
    }

    void CheckDistance()
    {
        if(navAgent.remainingDistance < 0.5f)
        {
            int dest = Random.Range(0, navPoints.Count);
            navAgent.SetDestination(GetNextWaypoint(dest).position);
        }
    }

    void AnimationController()
    {
        if(navAgent.velocity.magnitude <= 0.2)
        {
            anims.SetBool("isWalking", false);
        }
        else
        {
            anims.SetBool("isWalking", true);
        }
    }

    Transform GetNextWaypoint(int waypoint)
    {
        int nextWaypoint = 0;
        float maxDistance = 0;

        float minDistance = Vector3.Distance(transform.position, navPoints[waypoint].position);

        for (int i = waypoint; i < navPoints.Count; i++)
        {
            if (minDistance < Vector3.Distance(transform.position, navPoints[i].position))
            {
                return navPoints[i]; 
            }
        }

        return navPoints[nextWaypoint]; 
    }
}
