using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    CarBehaviour carAgent;
    AudioSource audio;
    [SerializeField]
    AudioClip beep; 

    void Start()
    {
        audio = GetComponent<AudioSource>();
        carAgent = GetComponentInParent<CarBehaviour>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pedestrian" || col.gameObject.tag == "Car" || col.gameObject.tag == "Player")
        {
            carAgent.navAgent.Stop(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pedestrian" || other.gameObject.tag == "Player")
            audio.PlayOneShot(beep);
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Pedestrian" || other.gameObject.tag == "Car" || other.gameObject.tag == "Player") && !carAgent.stoppedLights)
        {
            carAgent.navAgent.Resume();
        }
    }
}
