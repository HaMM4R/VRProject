using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string round = "Round: " + GameManager.instance.round.ToString() + " Number of zombies in round: " + GameManager.instance.numOfZombies.ToString() + " Num of zombies spawned: " + GameManager.instance.curSpawnedRoundZombies.ToString() + " Num of zombies killed: " + GameManager.instance.zombiesKilledInRound.ToString() +  "\n\n" + "Player Points:" + GameManager.instance.playerPoints.ToString(); 
        GetComponent<TextMeshPro>().text = round;
    }
}
