using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [SerializeField]
    GameObject greenLight;

    [SerializeField]
    GameObject redLight;

    private bool isGreen;

    public List<PedestrianBehaviour> pedestrianAgents = new List<PedestrianBehaviour>();
    public List<CarBehaviour> carAgents = new List<CarBehaviour>(); 

    public bool IsGreen 
    {
        get 
        {
            return isGreen;
        }
        set 
        {
            isGreen = value;

            if (isGreen)
                SetGreen();
            else
                SetRed(); 
        }
    }
    
    void SetGreen()
    {
        greenLight.SetActive(true);
        redLight.SetActive(false);

        if (carAgents != null)
        {
            foreach (CarBehaviour c in carAgents)
            {
                c.navAgent.Resume();
            }

            carAgents.Clear();
        }
    }

    void SetRed()
    {
        greenLight.SetActive(false);
        redLight.SetActive(true);

        if (pedestrianAgents != null)
        {
            foreach (PedestrianBehaviour c in pedestrianAgents)
            {
                c.navAgent.Resume();
            }

            pedestrianAgents.Clear();
        }
    }
}
