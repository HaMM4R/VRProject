using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBarrier : MonoBehaviour
{
    private ZombieManager manager; 
    public Window win;

    bool inColldier;

    float removeTimer;
    float removeTimerHolder = 3;

    float enterTimer = 2;

    private void Start()
    {
        manager = GetComponent<ZombieManager>();
        removeTimer = removeTimerHolder; 
    }

    void Update()
    {
        RemoveBarrier();
        Enter(); 
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

    void RemoveBarrier()
    {
        if(win != null)
        {
            if (removeTimer > 0)
                removeTimer -= Time.deltaTime;
            else
            {
                win.RemoveBarrier(); 
                removeTimer = removeTimerHolder;
            }
        }
    }

    void Enter()
    {
        if (win != null)
        {
            if (win.windowClear)
            {
                if (enterTimer > 0)
                    enterTimer -= Time.deltaTime;
                else
                {
                    manager.SetupTarget(win.EnterPoint);
                    win = null;
                }
            }
        }
    }
}
