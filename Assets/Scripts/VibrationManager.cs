using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager instance;

    void Start()
    {
        if (instance && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    public void TriggerVibration(int interation, int frequency, int strength, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < interation; i++) 
        { 
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0); 
        }

        if (controller == OVRInput.Controller.LTouch)
            OVRHaptics.LeftChannel.Preempt(clip);

        if (controller == OVRInput.Controller.RTouch)
            OVRHaptics.RightChannel.Preempt(clip);
    }
}
