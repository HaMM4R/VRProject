using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.None;
    public Transform look; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Haptics(); 
    }

    void Haptics()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
            VibrationManager.instance.TriggerVibration(80,4,255,controller);
    }
}
