using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicStopController : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    private AudioSource audioData, pause;
    
    // Start is called before the first frame update
    void Start()
    {
        audioData = a.GetComponent<AudioSource>();
        pause = b.GetComponent<AudioSource>();
        audioData.Play();
        }

    public void stop()
    {
        audioData.mute = true;
        pause.mute = true;
    }
    public void pauseMusic(bool activate)
    {
        if (activate) {
            pause.Play();
            audioData.Stop();
        }
        else
        {
            pause.Stop();
            audioData.Play();
        };
    }
}
