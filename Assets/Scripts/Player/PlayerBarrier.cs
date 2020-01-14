using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrier : MonoBehaviour
{
    public Window win;

    //REFACTOR FOR INPUT CONTROLLER
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && win != null)
            win.ReplaceBarrier(); 
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
