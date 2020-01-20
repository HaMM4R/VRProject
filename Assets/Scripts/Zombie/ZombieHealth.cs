using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    ZombieManager manager; 
    //SET DYNAMICALLY THROUGH SPAWNER FOR HIGHER ROUNDS
    float health = 100;
    public float Health { set { health = value; } }
    bool dead; 

    private void Start()
    {
        manager = GetComponent<ZombieManager>();
        dead = false; 
    }

    public void TakeDamage(float dmg)
    {
        //Refactor
        GameManager.instance.playerPoints += 10;
        health -= dmg;
        if (health < 0 && !dead)
            Die(); 
    }

    //CLEAR ZOMBIE OUT OF GAME MANAGER COLLECTION
    //CREATE POOLING SYSTEM
    void Die()
    {
        dead = true; 
        manager.Die(); 
    }
}
