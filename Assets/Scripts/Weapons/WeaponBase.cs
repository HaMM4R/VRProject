using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField]
    float dmg;
    [SerializeField]
    int magAmmo;
    [SerializeField]
    int reserveAmmo;
    [SerializeField]
    Transform fireOrigin;

    [SerializeField]
    GameObject debugHit; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fire(); 
    }

    void Fire()
    {
        RaycastHit hit; 

        if(Physics.Raycast(fireOrigin.position, transform.forward, out hit, 1000))
        {
            Instantiate(debugHit, hit.point, Quaternion.identity);
            if(hit.transform.gameObject.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponent<ZombieHealth>().TakeDamage(dmg);
            }
        }
    }
}
