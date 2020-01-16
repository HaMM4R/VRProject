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
    Transform muzzleFlashTransform;
    [SerializeField]
    GameObject muzzle;

    [SerializeField]
    GameObject debugHit;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip shoot;


    [SerializeField]
    GameObject hitEffectZombie;

    [SerializeField]
    GameObject hitEffectWall;

    //REREWRITE
    float fireTimer = 0.08f;
    float fireTimerHolder;

    void Start()
    {
        fireTimerHolder = fireTimer; 
    }

    void Update()
    {
        bool bDown = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
        if (bDown || Input.GetMouseButtonDown(0))
            Fire(); 

        /*if (fireTimer > 0)
            fireTimer -= Time.deltaTime; 
        else
        {
            fireTimer = fireTimerHolder;
            //REPLACE WITH INPUT MANAGER
            if (Input.GetMouseButtonDown(0) || (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.1f))
                Fire();
        }*/

    }

    void Fire()
    {
        RaycastHit hit;

        Instantiate(muzzle, muzzleFlashTransform.position, muzzleFlashTransform.rotation);
        source.PlayOneShot(shoot);

        if(Physics.Raycast(fireOrigin.position, transform.forward, out hit, 1000))
        {
            if(hit.transform.gameObject.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponent<ZombieHealth>().TakeDamage(dmg);
                Instantiate(hitEffectZombie, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
            else
            {
                Instantiate(hitEffectWall, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
    }
}
