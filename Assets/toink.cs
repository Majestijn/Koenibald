using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toink : MonoBehaviour
{
    public Collider2D shovelcollider;
    private Collider2D myCollider;
    public AudioSource audio;
    public PlayerController thePlayer;
    public AudioClip a;
    public bool played;
    void Start()
    {
        played = false;
        audio = GetComponent<AudioSource>();
        thePlayer = FindObjectOfType<PlayerController>();
        myCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Physics2D.IsTouching(myCollider, shovelcollider) && thePlayer.isShoveling &&!played)
        {
            if(!audio.isPlaying)audio.PlayOneShot(a, 1);
        }
        if (!thePlayer.isShoveling) played = false;
    }
}
