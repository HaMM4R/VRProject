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
    private ZombieAudio zAudio;
    public ZombieBarrier ZBarrier { get { return zBarrier; } }
    public ZombieHealth ZHealth { get { return zHealth; } }

    private Transform enterWindow; 
    public Transform setWindow { set { enterWindow = value; } }
    public GameManager GManager { set { gameManager = value; } get { return gameManager; } }

    bool inside; 
    public bool Inside { set { inside = value;  } get { return inside; } }

    void Start()
    {
        zHealth = GetComponent<ZombieHealth>();
        zMove = GetComponent<ZombieMovement>();
        zAnim = GetComponent<ZombieAnimation>();
        zBarrier = GetComponent<ZombieBarrier>();
        zAttack = GetComponent<ZombieAttack>();
        zAudio = GetComponent<ZombieAudio>();

        zMove.SetupMovement(enterWindow);
        zAttack.GetPlayer(gameManager.player);
        SendAnimChange(AnimType.run);
    }
    
    public void SetupTarget(Transform warpPos)
    {
        Debug.Log("TESTING");
        zMove.navAgent.Warp(warpPos.position);
        GameObject target = gameManager.Player;
        inside = true;
        zMove.SetTarget = target;
    }

    public void SendAnimChange(AnimType anim)
    {
        Debug.Log("AnimChange");
        zAnim.RecieveAnimChange(anim);
    }

    //REPLACE WITH STRUCTURE LIKE SEND ANIM CHANGES
    public void ZombieAttackSounds()
    {
        zAudio.PlayAttack(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Die(); 
    }

    public void Die()
    {
        zAnim.RecieveAnimChange(AnimType.die);
        zMove.navAgent.Stop();
        zMove.enabled = false;
        zAudio.enabled = false;
        zBarrier.enabled = false;
        StartCoroutine(DestroyThis());
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
