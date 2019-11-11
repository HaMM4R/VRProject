using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawn;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float fireWait; 

    float timer = 0;

    [SerializeField]
    AudioClip fireSound;
    
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime; 

        if((OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f) && timer <= 0)
        {
            Fire(); 
        }

    }

    void Fire()
    {
        timer = fireWait; 
        Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(fireSound); 
    }
}
