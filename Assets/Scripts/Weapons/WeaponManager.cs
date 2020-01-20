using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    public void ChangeWeapon(int id, int cost)
    {
        GameManager.instance.playerPoints -= cost; 
        for(int i = 0; i < weapons.Count; i++)
        {
            if (i == id)
                weapons[i].SetActive(true);
            else
                weapons[i].SetActive(false);
        }
    }
}
