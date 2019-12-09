using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianTrigger : MonoBehaviour
{
    PedestrianBehaviour pedestrianAgent;
    [SerializeField]
    Transform lookAt;
    void Start()
    {
        pedestrianAgent = GetComponentInParent<PedestrianBehaviour>();
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pedestrianAgent.navAgent.Stop();
            pedestrianAgent.lookAt = other.gameObject.transform; 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pedestrianAgent.navAgent.Resume();
            pedestrianAgent.lookAt = lookAt; 
        }
    }
}
