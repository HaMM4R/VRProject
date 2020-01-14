using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    private GameManager gameManager; 
    private ZombieHealth zHealth;
    private ZombieMovement zMove;
    private ZombieAnimation zAnim;
    private ZombieBarrier zBarrier;
    private ZombieAttack zAttack; 
    public ZombieBarrier ZBarrier { get { return zBarrier; } }
    public ZombieHealth ZHealth { get { return zHealth; } }

    private Transform enterWindow; 
    public Transform setWindow { set { enterWindow = value; } }
    public GameManager GManager { set { gameManager = value; } get { return gameManager; } }

    bool inside; 
    public bool Inside { set { inside = value; SetupTarget(); } get { return inside; } }

    void Start()
    {
        zHealth = GetComponent<ZombieHealth>();
        zMove = GetComponent<ZombieMovement>();
        zAnim = GetComponent<ZombieAnimation>();
        zBarrier = GetComponent<ZombieBarrier>();
        zAttack = GetComponent<ZombieAttack>();

        zMove.SetupMovement(enterWindow);
    }

    void SetupTarget()
    {
        GameObject target = gameManager.Player;
        zMove.SetTarget = target;
    }
}
