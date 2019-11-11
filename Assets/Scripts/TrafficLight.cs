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
    private List<PedestrianBehaviour> navAgents = new List<PedestrianBehaviour>(); 

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
    }

    void SetRed()
    {
        greenLight.SetActive(false);
        redLight.SetActive(true);

        if (navAgents != null)
        {
            foreach (PedestrianBehaviour c in navAgents)
            {
                c.navAgent.Resume();
            }

            navAgents.Clear();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Pedestrian" && isGreen)
        {
            Debug.Log("TESTING");
            var person = col.gameObject.GetComponent<PedestrianBehaviour>();
            navAgents.Add(person);
            person.navAgent.Stop(false);
        }
    }
}
