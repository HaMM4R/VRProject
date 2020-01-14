using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private List<GameObject> zombies = new List<GameObject>(); 

    public List<GameObject> Zombies { get { return zombies; } }
    public GameObject Player { get { return player; } }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
