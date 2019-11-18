using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightTrigger : MonoBehaviour
{
    TrafficLight trafficLight;

    void Start()
    {
        trafficLight = GetComponentInParent<TrafficLight>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pedestrian" && trafficLight.IsGreen)
        {
            var person = col.gameObject.GetComponent<PedestrianBehaviour>();

            if (!person.crossing)
            {
                trafficLight.pedestrianAgents.Add(person);
                person.navAgent.Stop(false);
            }
        }

        if(col.gameObject.tag == "Pedestrian")
        {
            var person = col.gameObject.GetComponent<PedestrianBehaviour>();
            if (person.crossing)
                person.crossing = false;
            else
                person.crossing = true; 
            Debug.Log(person.crossing);
        }

        if (col.gameObject.tag == "Car" && !trafficLight.IsGreen)
        {
            Debug.Log("TESTING");
            var car = col.gameObject.GetComponent<CarBehaviour>();
            trafficLight.carAgents.Add(car);
            car.stoppedLights = true; 
            car.navAgent.Stop(false);
        }
    }
}
