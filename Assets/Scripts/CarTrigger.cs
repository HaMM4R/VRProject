using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    CarBehaviour carAgent;
    AudioSource audio;
    [SerializeField]
    AudioClip beep;

    bool hasBeeped;


    void Start()
    {
        hasBeeped = false;
        audio = GetComponent<AudioSource>();
        carAgent = GetComponentInParent<CarBehaviour>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pedestrian" || col.gameObject.tag == "Car" || col.gameObject.tag == "PlayerNew")
        {
            carAgent.navAgent.isStopped = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pedestrian" || other.gameObject.tag == "PlayerNew")
        {
            carAgent.navAgent.isStopped = true;
            if (!hasBeeped)
            {
                Debug.Log("BBEP");
                audio.PlayOneShot(beep);
                StartCoroutine(PlaySound());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Pedestrian" || other.gameObject.tag == "Car" || other.gameObject.tag == "PlayerNew") && !carAgent.stoppedLights)
        {
            Debug.Log("Unbeep");
            carAgent.navAgent.isStopped = false;
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(4);
        hasBeeped = false;
    }
}
