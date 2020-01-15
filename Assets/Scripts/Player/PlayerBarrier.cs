using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    public Window win;
    //REREWRITE
    float windowTimer = 1f;
    float windowTimerHolder;

    void Start()
    {
        windowTimer = windowTimerHolder; 
    }

    //REFACTOR FOR INPUT CONTROLLER
    void Update()
    {
        if (windowTimer > 0)
            windowTimer -= Time.deltaTime;
        else
        {
            windowTimer = windowTimerHolder;
            //REPLACE WITH INPUT MANAGER
            if ((Input.GetKeyDown(KeyCode.E) || (OVRInput.Get(OVRInput.Button.One))) && win != null)
                win.ReplaceBarrier();
        }
    }

    //REFACTOR FOR INHERITENCE FOR ZOMBIE AND PLAYER
    public void InWindow(Window w)
    {
        Debug.Log("Test2");
        win = w;
    }

    public void OutWindow()
    {
        win = null;
    }
}
