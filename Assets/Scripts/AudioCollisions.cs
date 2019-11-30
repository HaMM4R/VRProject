using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollisions : MonoBehaviour
{
	[SerializeField]
	List<AudioClip> sounds = new List<AudioClip>();
	AudioSource source; 
	bool hasPlayed = false;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}


	void OnTriggerEnter(Collision collision)
	{
		if(!hasPlayed)
			source.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
		
		hasPlayed = true;
	}

	void OnTriggerExit(Collision collision)
	{
		hasPlayed = false; 
	}
}
