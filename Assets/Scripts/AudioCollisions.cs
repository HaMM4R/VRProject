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

    
}
