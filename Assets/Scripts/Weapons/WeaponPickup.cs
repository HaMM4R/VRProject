using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    //Refactor to get component
    public WeaponManager weaponManager; 
    void OnTriggerEnter(Collider otherCollider)
    {
        // Get the grab trigger
        if(otherCollider.gameObject.tag == "WallWeapons")
        {
            var weapon = otherCollider.GetComponent<WeaponWall>();
            
            if (GameManager.instance.playerPoints >= weapon.cost)
                weaponManager.ChangeWeapon(weapon.id, weapon.cost);
        }
    }
}
