using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField]
    List<Spawns> spawning = new List<Spawns>();

    [SerializeField]
    GameObject zombie;

    [SerializeField]
    int numberOfSpawnWaves = 0;

    [SerializeField]
    float spawnTimer = 6.2f;
    float spawnTimerHolder;

    int spawnQueue = 0;
    float zombieHealth;
    float zombieSpeed; 

    void Start()
    {
        spawnTimerHolder = spawnTimer; 
    }

    void Update()
    {
        if(spawnQueue > 0)
        {
            if (spawnTimer > 0)
                spawnTimer -= Time.deltaTime; 
            else
            {
                int initSpawn = Random.Range(0, spawning.Count);
                spawnQueue--;
                spawnTimer = spawnTimerHolder; 
                Spawn(initSpawn);
            }
        }
    }

    public void SpawnBehaviour(int numToSpawn, float health, float speed)
    {
        spawnQueue += numToSpawn;
        zombieHealth = health;
        zombieSpeed = speed; 
    }

    void Spawn(int point)
    {
        GameObject z = Instantiate(zombie, spawning[point].spawnPoint.position, spawning[point].spawnPoint.rotation) as GameObject;
        int selectedWindow = Random.Range(0, spawning[point].windows.Count);
        var zManager = z.GetComponent<ZombieManager>();
        zManager.SetupZombie(zombieHealth, zombieSpeed, spawning[point].windows[selectedWindow]);
        //zManager.setWindow = spawning[point].windows[selectedWindow];
        //zManager.GManager = gameManager;
        GameManager.instance.Zombies.Add(z);
    }
}

[System.Serializable]
public struct Spawns
{
    public Transform spawnPoint;
    public List<Transform> windows; 
}
