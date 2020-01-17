using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    ZombieManager manager; 
    //SET DYNAMICALLY THROUGH SPAWNER FOR HIGHER ROUNDS
    float health = 100;

    private void Start()
    {
        manager = GetComponent<ZombieManager>();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health < 0)
            Die(); 
    }

    //CLEAR ZOMBIE OUT OF GAME MANAGER COLLECTION
    //CREATE POOLING SYSTEM
    void Die()
    {
        manager.Die(); 
    }
}
