using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public Window win;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Debug.Log("Test1");
            other.GetComponent<ZombieManager>().ZBarrier.InWindow(win);
        }

        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerManager>().PBarrier.InWindow(win);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            other.GetComponent<ZombieManager>().ZBarrier.OutWindow();
        }

        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerManager>().PBarrier.OutWindow();
        }
    }
}
