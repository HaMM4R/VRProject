using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerHealth pHealth;
    private PlayerBarrier pBarrier; 

    public PlayerBarrier PBarrier { get { return pBarrier; } }

    void Start()
    {
        pHealth = GetComponent<PlayerHealth>();
        pBarrier = GetComponent<PlayerBarrier>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
