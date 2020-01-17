using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFootEvent : MonoBehaviour
{
    public void PlayFoot()
    {
        GetComponentInParent<ZombieAudio>().PlayFootstep(); 
    }
}
