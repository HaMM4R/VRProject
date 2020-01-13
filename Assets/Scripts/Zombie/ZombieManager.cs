using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    private ZombieHealth zHealth;
    private ZombieMovement zMove;
    private ZombieAnimation zAnim;
    private ZombieBarrier zBarrier;
    public ZombieBarrier ZBarrier { get { return zBarrier; } }

    private Transform enterWindow; 
    public Transform setWindow { set { enterWindow = value; } }

    bool inside; 
    public bool Inside { set { inside = value; /* call start to follow player */ } }

    void Start()
    {
        zHealth = GetComponent<ZombieHealth>();
        zMove = GetComponent<ZombieMovement>();
        zAnim = GetComponent<ZombieAnimation>();
        zBarrier = GetComponent<ZombieBarrier>();

        zMove.SetupMovement(enterWindow);
    }

    void Update()
    {
        
    }
}
