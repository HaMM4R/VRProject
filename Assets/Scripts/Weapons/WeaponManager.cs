using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    public List<GameObject> weaponMags = new List<GameObject>();

    [SerializeField]
    WeaponBase curWeapon;
    //REPLACE WITH FIELD IN WEAPONBASE
    int curID = 0;

    bool isReloading = false; 

    public void ChangeWeapon(int id, int cost)
    {
        GameManager.instance.playerPoints -= cost; 
        for(int i = 0; i < weapons.Count; i++)
        {
            if (i == id)
            {
                weapons[i].SetActive(true);
                curWeapon = weapons[i].GetComponent<WeaponBase>();
                curID = i; 
            }
            else
                weapons[i].SetActive(false);
        }
    }

    //REPLACE WITH OVR GRABBER
    public void GetMag()
    {
        for (int i = 0; i < weaponMags.Count; i++)
        {
            if (i == curID)
                weaponMags[i].SetActive(true);
            else
                weaponMags[i].SetActive(false);
        }
        isReloading = true; 
    }

    public void LoadWeapon()
    {
            curWeapon.Reload();
            isReloading = false;
        GameManager.instance.playerPoints += 50;

            for (int i = 0; i < weapons.Count; i++)
                weaponMags[i].SetActive(false);
        
    }
}
