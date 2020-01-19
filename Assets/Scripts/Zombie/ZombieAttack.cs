using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    GameObject player;
    float attackTimer = 1;
    float attackTimerHolder; 

    public void GetPlayer(GameObject p)
    {
        player = p; 
    }

    void Start()
    {
        attackTimerHolder = attackTimer;
        attackTimer = 0; 
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        //PERFORM CHECK TO SEE IF WITHIN A CERTAIN FRAMEWORK
        /*if(Vector3.Distance(transform.position, player.transform.position) < 0.5f)
        {
            if (attackTimer > 0)
                attackTimer -= Time.deltaTime;
            else
            {
                Attack(); 
                attackTimer = attackTimerHolder;
            }
        }*/
    }

    void Attack()
    {
        player.GetComponent<PlayerHealth>(); 
    }
}
