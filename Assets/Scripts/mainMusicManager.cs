using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMusicManager : MonoBehaviour
{
    public AudioSource MyAudioSource, pauseAudioSource;

    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
        pauseAudioSource = FindObjectOfType<AudioSource>();

    }

    public void pauseMusic(bool state)
    {
        MyAudioSource.mute = state;
        pauseAudioSource.mute = !state;
    }
	public void stopMusic()
    {
        MyAudioSource.mute = true;
    }

}
