using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    ZombieManager manager; 

    [SerializeField]
    AudioSource sourceGrunts;

    [SerializeField]
    AudioSource sourceAttacks;

    [SerializeField]
    AudioSource sourceFoot;

    [SerializeField]
    List<AudioClip> zombieGrunts = new List<AudioClip>();

    [SerializeField]
    List<AudioClip> footsteps = new List<AudioClip>();

    [SerializeField]
    List<AudioClip> attack = new List<AudioClip>();

    float gruntTimer; 

    void Start()
    {
        manager = GetComponent<ZombieManager>(); 
        gruntTimer = Random.Range(0, 20);
    }
    

    void Update()
    {
        Grunts();
    }

    public void PlayAttack()
    {
        sourceAttacks.PlayOneShot(attack[RandomChoice(attack.Count)]);
    }

    void Grunts()
    {
        if (gruntTimer > 0)
            gruntTimer -= Time.deltaTime;
        else
        {
            sourceGrunts.PlayOneShot(zombieGrunts[RandomChoice(zombieGrunts.Count)]);
            gruntTimer = Random.Range(0, 20);
        }
    }

    public void PlayFootstep()
    {
        Debug.Log("FIREFOOTSOUND");
        sourceFoot.PlayOneShot(footsteps[RandomChoice(footsteps.Count)]);
    }

    int RandomChoice(int length)
    {
        int choice = Random.Range(0, length);
        return choice;
    }
}
