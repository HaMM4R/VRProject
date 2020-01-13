using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField]
    List<Spawns> spawning = new List<Spawns>();

    [SerializeField]
    GameObject zombie; 

    void Start()
    {
        for(int i = 0; i < spawning.Count; i++)
        {
            GameObject z = Instantiate(zombie, spawning[i].spawnPoint.position, spawning[i].spawnPoint.rotation) as GameObject;
            int selectedWindow = Random.Range(0, spawning[i].windows.Count);
            z.GetComponent<ZombieManager>().setWindow = spawning[i].windows[selectedWindow];

        }
    }
}
[System.Serializable]
public struct Spawns
{
    public Transform spawnPoint;
    public List<Transform> windows; 
}
