using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    ZombieManager manager;
    [SerializeField]
    Animator animator; 

    void Start()
    {
        manager = GetComponent<ZombieManager>();
    }

    public void RecieveAnimChange(AnimType a)
    {
        if (a == AnimType.walk)
            Walk();
        if (a == AnimType.run)
            Run();
        if (a == AnimType.idle)
            Idle();
        if (a == AnimType.attack)
            Attack();
        if (a == AnimType.die)
            Die(); 
    }

    void Walk()
    {
        if (GameManager.instance.Round < 5)
        {
            int choice = Random.Range(0, 1);

            string walk = choice == 0 ? "isWalking1" : "isWalking2";
            animator.SetBool(walk, true);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        animator.SetBool("isAttacking", false);
    }

    void Run()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isAttacking", false);
    }

    void Attack()
    {
        animator.SetTrigger("isAttacking");
        animator.SetBool("isWalking1", false);
        animator.SetBool("isWalking2", false);
        animator.SetBool("isRunning", false);
    }

    void Die()
    {
        int choice = Random.Range(0, 1);

        string die = choice == 0 ? "isFalling" : "isFalling2";
        animator.SetBool(die, true);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking1", false);
        animator.SetBool("isWalking2", false);
        animator.SetBool("isRunning", false);
    }

    void Idle()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking1", false);
        animator.SetBool("isWalking2", false);
        animator.SetBool("isRunning", false);
    }
    
}

public enum AnimType
{
    walk,
    run,
    idle,
    attack,
    die
}

public enum ZombieType
{
    walking,
    running
}