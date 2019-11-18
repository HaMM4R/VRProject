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
        if (col.gameObject.tag == "Pedestrian" || col.gameObject.tag == "Car" || col.gameObject.tag == "Player")
        {
            carAgent.navAgent.Stop(false);
            Debug.Log("TESTingwag");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Pedestrian" || other.gameObject.tag == "Car" || other.gameObject.tag == "Player") && !carAgent.stoppedLights)
        {
            Debug.Log("CARG");
            carAgent.navAgent.Resume();
        }
    }
}
