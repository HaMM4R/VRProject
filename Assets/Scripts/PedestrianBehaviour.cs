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

    public bool crossing;

    [SerializeField]
    Transform neckBone;
    [SerializeField]
    Transform lookAt;
    void Start()
    {
        crossing = false; 
        navAgent = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>(); 
        SetupNavPoints();
        StartCoroutine(Test());

        int destination = Random.Range(0, navPoints.Count);
        navAgent.SetDestination(navPoints[destination].position);
    }

    // Update is called once per frame
    void Update()
    {
        AdjustLook();
        CheckDistance();
        AnimationController(); 
    }

    void LateUpdate()
    { 
        NeckController(); 
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
        if(navAgent.velocity.magnitude <= 0.2f)
        {
            anims.SetBool("isWalking", false);
        }
        else
        {
            anims.SetBool("isWalking", true);
        }
    }

    void NeckController()
    {
        neckBone.LookAt(lookAt);
    }

    void AdjustLook()
    {
        lookAt.Translate(Vector3.left * Time.deltaTime);
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

    IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
        AdjustLook(); 
    }
}
