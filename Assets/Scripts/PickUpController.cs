using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
	public PlayerController thePlayer;
	public Renderer rend;
	public bool isBucket;
	public GameObject poef;
	public GameObject position;

	void Start()
	{
		rend = GetComponent<Renderer>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Instantiate(poef, position.transform.position, transform.rotation);
			rend.enabled = thePlayer.PickUp(isBucket);
		}
	}
}