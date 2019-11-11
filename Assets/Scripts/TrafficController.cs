using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    List<TrafficLight> trafficLights = new List<TrafficLight>();

    [SerializeField]
    float timer; 
    float timerHolder;

    int activeLight; 

    void Start()
    {
        activeLight = 0;
        timerHolder = timer;
        GetTrafficLights();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLightState(); 
    }

    void GetTrafficLights()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("TrafficLight");

        for(int i = 0; i < lights.Length; i++)
        {
            trafficLights.Add(lights[i].GetComponent<TrafficLight>());
            trafficLights[i].IsGreen = false; 
        }

        trafficLights[activeLight].IsGreen = true; 
    }

    void UpdateLightState()
    {
        timerHolder -= Time.deltaTime; 

        if(timerHolder < 0)
        {
            timerHolder = timer;
            trafficLights[activeLight].IsGreen = false;

            if (activeLight == trafficLights.Count - 1)
                activeLight = 0;
            else
                activeLight++;

            trafficLights[activeLight].IsGreen = true;
        }
    }
}
