using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianBehaviour : MonoBehaviour
{
    public List<Transform> navPoints = new List<Transform>();
    public NavMeshAgent navAgent;

    AudioSource audio;
    public List<AudioClip> sounds = new List<AudioClip>(); 

    [SerializeField]
    Animator anims;

    public bool crossing;

    [SerializeField]
    Transform neckBone;
    [SerializeField]
    Transform lookAt;

    float lookTimer;
    float lookHolder; 

    void Start()
    {
        crossing = false; 
        navAgent = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
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
            anims.speed = 1;
            anims.SetBool("isWalking", false);
        }
        else
        {
            anims.speed = (navAgent.velocity.magnitude / 2);
            anims.SetBool("isWalking", true);
        }
    }

    void NeckController()
    {
        neckBone.LookAt(lookAt);
    }

    void PlayFootstepSound()
    {
        int rand = Random.Range(0, sounds.Count);
        audio.PlayOneShot(sounds[rand]);
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
