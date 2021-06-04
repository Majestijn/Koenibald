using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
	public LayerMask WhatIsEnemy;
	
	public Renderer rend;
	private PolygonCollider2D myCollider;

    AudioSource audioData;
    public AudioClip hit;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<PolygonCollider2D>();
        audioData = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
        
    }

	
    // Update is called once per frame
    void Update()
    {
		    if(Physics2D.IsTouchingLayers(myCollider, WhatIsEnemy)){
			rend.enabled=false;
            if(!audioData.isPlaying)audioData.PlayOneShot(hit, 1);
        }
    }
}
