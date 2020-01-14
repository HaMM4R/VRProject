using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    GameManager gameManager; 

    [SerializeField]
    List<Spawns> spawning = new List<Spawns>();

    [SerializeField]
    GameObject zombie;

    int numToSpawn = 3;
    int numberOfSpawnWaves = 0;

    float spawnTimer = 13;
    float spawnTimerHolder; 

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        spawnTimerHolder = spawnTimer; 
        SpawnBehaviour();  
    }

    //REMOVE JUST FOR SPAWN TESTING
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            SpawnBehaviour(); 
        }

        SpawnTimer(); 
    }

    //TIE INTO GAME MANAGER THAT WILL CONTROL WAVES AND NUMBER OF ZOMBIES TO SPAWN PER WAVE ETC
    void SpawnTimer()
    {
        if (spawnTimer > 0)
            spawnTimer -= Time.deltaTime;
        else
        {
            SpawnBehaviour();
            numberOfSpawnWaves++; 

            //Increases number to spawn every 5 spawn sets
            if(numberOfSpawnWaves % 5 == 0)
            {
                numToSpawn++; 
            }

            spawnTimer = spawnTimerHolder;
        }
    }

    void SpawnBehaviour()
    {
        for(int i = 0; i <= numToSpawn; i++)
        {
            int initSpawn = Random.Range(0, spawning.Count);
            Spawn(initSpawn);
        }
    }

    void Spawn(int point)
    {
        GameObject z = Instantiate(zombie, spawning[point].spawnPoint.position, spawning[point].spawnPoint.rotation) as GameObject;
        int selectedWindow = Random.Range(0, spawning[point].windows.Count);
        var zManager = z.GetComponent<ZombieManager>();
        zManager.setWindow = spawning[point].windows[selectedWindow];
        zManager.GManager = gameManager;
        gameManager.Zombies.Add(z);
    }
}
[System.Serializable]
public struct Spawns
{
    public Transform spawnPoint;
    public List<Transform> windows; 
}
