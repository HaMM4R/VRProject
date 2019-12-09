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
    public Transform lookAt;

    float lookTimer;
    float lookHolder;

    float randStart; 

    void Start()
    {
        crossing = false; 
        navAgent = GetComponent<NavMeshAgent>();
        anims = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        SetupNavPoints();

        randStart = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        AnimationController();

        if (randStart > 0)
            StartPedestrian();
        else
            CheckDistance();
    }

    void StartPedestrian()
    {
        if (randStart > 0)
            randStart -= Time.deltaTime; 

        if(randStart <= 0)
        {
            int destination = Random.Range(0, navPoints.Count);
            navAgent.SetDestination(navPoints[destination].position);
        }
        
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
        if (lookAt != null)
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
