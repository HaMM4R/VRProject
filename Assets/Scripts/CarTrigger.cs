using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    CarBehaviour carAgent;

    void Start()
    {
        carAgent = GetComponentInParent<CarBehaviour>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pedestrian" || col.gameObject.tag == "Car")
        {
            carAgent.navAgent.Stop(false); 
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Pedestrian" || other.gameObject.tag == "Car") && !carAgent.stoppedLights)
        {
            Debug.Log("CARG");
            carAgent.navAgent.Resume();
        }
    }
}
