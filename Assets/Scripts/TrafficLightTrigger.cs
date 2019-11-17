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

            person.crossing = false; 
        }

        if(col.gameObject.tag == "Pedestrian" && !trafficLight.IsGreen)
        {
            var person = col.gameObject.GetComponent<PedestrianBehaviour>();
            person.crossing = true; 
        }

        if (col.gameObject.tag == "Car" && !trafficLight.IsGreen)
        {
            Debug.Log("TESTING");
            var car = col.gameObject.GetComponent<CarBehaviour>();
            trafficLight.carAgents.Add(car);
            car.navAgent.Stop(false);
        }
    }
}
