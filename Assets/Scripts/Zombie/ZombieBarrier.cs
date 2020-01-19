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

    Rigidbody rigidB;

    private void Start()
    {
        manager = GetComponent<ZombieManager>();
        rigidB = GetComponent<Rigidbody>();
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
        manager.SendAnimChange(AnimType.attack);
        rigidB.constraints = RigidbodyConstraints.FreezeAll; 
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
                manager.SendAnimChange(AnimType.attack);
                manager.ZombieAttackSounds();
            }
        }
    }

    void SetupConstraints()
    {
        rigidB.constraints = RigidbodyConstraints.None;
        rigidB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY; 
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
                    SetupConstraints(); 
                    manager.SetupTarget(win.EnterPoint);
                    manager.SendAnimChange(AnimType.walk);
                    win = null;
                }
            }
        }
    }
}
