using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianTrigger : MonoBehaviour
{
    PedestrianBehaviour pedestrianAgent;
    [SerializeField]
    AudioSource audio;

    public List<AudioClip> sounds = new List<AudioClip>(); 

    [SerializeField]
    Transform lookAt;

    [SerializeField]
    Transform defaultPosition;

    Transform player;

    bool lookAtPlayer;
    void Start()
    {
        pedestrianAgent = GetComponentInParent<PedestrianBehaviour>();
        pedestrianAgent.lookAt = lookAt;
    }

    void Update()
    {
        if (lookAtPlayer && player != null)
            lookAt.position = Vector3.Lerp(lookAt.position, player.position, Time.deltaTime * 2);
        else
            lookAt.position = Vector3.Lerp(lookAt.position, defaultPosition.position, Time.deltaTime * 2);

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerNew")
        {
            pedestrianAgent.navAgent.Stop();
            lookAtPlayer = true;
            player = other.gameObject.GetComponent<Player>().look;
            StartCoroutine(PlaySound());
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerNew")
        {
            pedestrianAgent.navAgent.Resume();
            lookAtPlayer = false;
            player = null;
            StopCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(3);
        int rnd = Random.Range(0, sounds.Count);
        audio.PlayOneShot(sounds[rnd]);
    }
}
