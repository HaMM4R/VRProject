using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class ZombieMovement : MonoBehaviour
{
    private ZombieManager manager;
    NavMeshAgent navAgent;

    void Start()
    {
        manager = GetComponent<ZombieManager>();
    }

    public void SetupMovement(Transform window)
    {
        Debug.Log(window);
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(window.position);
    }
}
