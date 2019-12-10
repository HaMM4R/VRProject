using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CarBehaviour : NavAgent
{
    public Transform[] wheels = new Transform[4];

    [SerializeField]
    Transform carDetection;

    public bool stoppedLights;

    void Update()
    {
        base.FindWaypoint();
        RotateWheels();
        AudioAdjust(); 
        //DetectCar(); 
    }

    void RotateWheels()
    {
        wheels[0].Rotate(0, 0, (navAgent.velocity.magnitude * Time.deltaTime) * 20);
        wheels[1].Rotate(0, 0, (navAgent.velocity.magnitude * Time.deltaTime) * 20);
        wheels[2].Rotate(0, 0, -((navAgent.velocity.magnitude * Time.deltaTime) * 20));
        wheels[3].Rotate(0, 0, -((navAgent.velocity.magnitude * Time.deltaTime) * 20));
    }

    void AudioAdjust()
    {
        GetComponent<AudioSource>().pitch = Mathf.Clamp(navAgent.velocity.magnitude / navAgent.speed, 0.05f, 1); 
    }

    void DetectCar()
    {
        RaycastHit hit;

        if(Physics.Raycast(carDetection.position, carDetection.forward, out hit, 50f))
        {
            if (hit.transform.gameObject.tag == "Car")
            {
                navAgent.Stop(false);
            }
        }
        else
        { 
            if(!stoppedLights)
                navAgent.Resume();
        }
    }
}
