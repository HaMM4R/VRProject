using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; 
    public static GameManager instance { get { return _instance; } }

    ZombieSpawn spawner; 
    public GameObject player;
    private List<GameObject> zombies = new List<GameObject>(); 

    public List<GameObject> Zombies { get { return zombies; } }
    public GameObject Player { get { return player; } }

    //Round Information
    int round;
    int maxZombiesInWorld = 15;
    float zombieHealth = 150;
    float zombieHealthIncrease = 100;

    float zombieSpeed = 1;
    float zombieSpeedMultiplier = 1.2f; 

    int numOfZombies = 6;
    int numToIncrease = 3;
    int zombiesKilledInRound; 

    float roundStartTimer = 12f;
    float roundStartHolder;

    int curSpawnedRoundZombies;
    bool roundEnded; 

    public int Round { get { return round; } }

    void Start()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this; 

        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.FindGameObjectWithTag("ZombieSpawner").GetComponent<ZombieSpawn>();
        roundStartHolder = roundStartTimer;
        StartRound(); 
    }

    void Update()
    {
        StartRoundTimer();
        if (Input.GetKeyDown(KeyCode.R))
            zombies[0].GetComponent<ZombieManager>().Die();
    }

    void StartRoundTimer()
    {
        if (roundEnded)
        {
            if (roundStartTimer > 0)
                roundStartTimer -= Time.deltaTime;
            else
            {
                StartRound();
                roundStartTimer = roundStartHolder; 
                roundEnded = false; 
            }
        }
    }

    void StartRound()
    {
        int numToSpawn = numOfZombies / 2;
        numToSpawn = numToSpawn > maxZombiesInWorld ? maxZombiesInWorld : numOfZombies / 2;

        curSpawnedRoundZombies += numToSpawn; 

        spawner.SpawnBehaviour(numToSpawn, zombieHealth, zombieSpeed);
    }

    public void ZombieKilled(GameObject zombieKilled)
    {
        if (curSpawnedRoundZombies != numOfZombies)
        {
            spawner.SpawnBehaviour(1, zombieHealth, zombieSpeed);
            curSpawnedRoundZombies++;
        }

        zombiesKilledInRound++;
        zombies.Remove(zombieKilled);
        if (zombiesKilledInRound == numOfZombies)
            EndRound();

    }

    void EndRound()
    {
        zombiesKilledInRound = 0;
        curSpawnedRoundZombies = 0;

        numOfZombies += numToIncrease;
        zombieHealth += zombieHealthIncrease;
        zombieSpeed *= zombieSpeedMultiplier;

        round++; 

        roundEnded = true; 
    }
}
