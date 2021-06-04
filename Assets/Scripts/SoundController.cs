using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    public AudioClip mySound;
	AudioSource audioData;
    private bool alreadyPlayed;

    void Start()
    {
        alreadyPlayed = false;
        audioData = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D(Collider2D other){
        if (other.transform.CompareTag("Player") && !alreadyPlayed)
        {
            print("Playing SOUND!");
            audioData.PlayOneShot(mySound, 1);
            alreadyPlayed = true;
        }
	}

}