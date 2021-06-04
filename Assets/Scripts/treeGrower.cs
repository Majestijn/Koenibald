using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeGrower : MonoBehaviour
{

	public Renderer myRend;
	public Collider2D shovelcollider;
	private Collider2D myCollider;
	public AudioSource audio;
	public PlayerController thePlayer;
	public GameObject effect;
	public AudioClip a;
	public AudioSource toinkSource;
	private bool played;
	void Start()
	{
		played = false;
		audio = GetComponent<AudioSource>();
		thePlayer = FindObjectOfType<PlayerController>();
		myCollider = GetComponent<Collider2D>();
		myRend = GetComponent<Renderer>();
		myRend.enabled = false;
	}
	void Update()
	{
		//if (Physics2D.IsTouching(myCollider, shovelcollider) && thePlayer.isShoveling && !played)
		//{
		//	Instantiate(effect, new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), transform.rotation);
		//	audio.PlayOneShot(a, 1);
		//	myRend.enabled = true;
		//	played = true;
		//}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "shovel" && thePlayer.isShoveling)
		{
			thePlayer.hasShovelHitGrass = true;
			toinkSource.volume = 0f;
			Instantiate(effect, new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), transform.rotation);
			audio.PlayOneShot(a, 1);
			myRend.enabled = true;
			thePlayer.StartCoroutine(thePlayer.DisableShovelRoutine());
		}
	}

	//void OnCollisionEnter2D(Collision2D other)
	//{
	//	if (other.gameObject.name == "shovel" && thePlayer.isShoveling)
	//	{
	//		Instantiate(effect, new Vector3(transform.position.x, transform.position.y - 3, transform.position.z), transform.rotation);
	//		audio.PlayOneShot(a, 1);
	//		myRend.enabled = true;
	//		thePlayer.DisableShoveling();
	//	}
	//}



}