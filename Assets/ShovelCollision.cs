using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelCollision : MonoBehaviour
{

	PlayerController playerController;
	AudioSource audioSource;
	public LayerMask layerMask;

	public string[] toinkMask;

	void Start()
	{
		playerController = transform.root.GetComponent<PlayerController>();
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (IsInLayerMask(other.gameObject.layer, layerMask) && !playerController.hasShovelHitGrass)
		{
			audioSource.volume = 1f;
			playerController.StartCoroutine(playerController.DisableShovelRoutine());
			if (playerController.isShoveling)
				audioSource.Play();

		}
	}

	public  bool IsInLayerMask(int layer, LayerMask layermask)
	{
		return layermask == (layermask | (1 << layer));
	}
}
