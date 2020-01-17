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

    [SerializeField]
    Transform recoilHolder;

    [SerializeField]
    Vector3 kickMove;

    [SerializeField]
    Vector3 kickRot;

    Vector3 kickHolder1;
    Vector3 kickHolder2;
    Vector3 kickHolder3;
    Vector3 kickHolder4; 


    void Start()
    {
        fireTimerHolder = fireTimer; 
    }

    void Update()
    {
        Recoil(); 

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

        kickHolder1 += kickRot;
        kickHolder3 += kickMove; 

        if(Physics.Raycast(fireOrigin.position, transform.forward, out hit, 1000))
        {
            if(hit.transform.gameObject.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponentInParent<ZombieHealth>().TakeDamage(dmg);
                Instantiate(hitEffectZombie, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
            else
            {
                Instantiate(hitEffectWall, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
    }

    void Recoil()
    {
        kickHolder1 = Vector3.Lerp(kickHolder1, Vector3.zero, 0.1f);
        kickHolder2 = Vector3.Lerp(kickHolder2, kickHolder1, 0.1f);
        kickHolder3 = Vector3.Lerp(kickHolder3, Vector3.zero, 0.1f);
        kickHolder4 = Vector3.Lerp(kickHolder4, kickHolder3, 0.1f);

        recoilHolder.localEulerAngles = kickHolder1 * 40f;
        recoilHolder.localPosition = kickHolder3; 
    }
}
