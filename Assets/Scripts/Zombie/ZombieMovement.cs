using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class ZombieMovement : MonoBehaviour
{
    private ZombieManager manager;
    private GameObject target; 
    NavMeshAgent navAgent;

    public GameObject SetTarget { set { target = value; } }

    bool debugTrack = false; 

    void Start()
    {
        manager = GetComponent<ZombieManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            debugTrack = true; 
        if (target != null)
            if(!debugTrack)
                TrackTarget(); 
    }

    public void SetupMovement(Transform window)
    {
        Debug.Log(window);
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(window.position);
    }

    private void TrackTarget()
    {
        navAgent.SetDestination(target.transform.position);
    }
}
