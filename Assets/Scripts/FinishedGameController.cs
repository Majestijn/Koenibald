using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedGameController : MonoBehaviour
{
	public PlayerController thePlayer;
	public Renderer endScreen;
	public AudioClip victory;
	public AudioSource audioData;
    public Canvas thecanvas;
    public GameObject victoryeffect;
    private bool activated;
    void Start()
    {
        activated = false;
        audioData = GetComponent<AudioSource>();
 thePlayer = FindObjectOfType<PlayerController>();
 endScreen = GetComponent<Renderer>();
 endScreen.enabled=false;
       	}
	void OnTriggerEnter2D(Collider2D other){
        if (!activated)
        {
            Instantiate(victoryeffect);
            activated = true;

        }
        thecanvas.gameObject.SetActive(false);
	if (!audioData.isPlaying)
        {
		audioData.PlayOneShot(victory,1);}
        thePlayer.DisablePic();

        endScreen.enabled=true;
	thePlayer.victory=true;
}

}