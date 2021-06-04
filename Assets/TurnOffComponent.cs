using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffComponent : MonoBehaviour
{
	public PlatformEffector2D component;
	public BoxCollider2D boxCollider;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			component.enabled = false;
			boxCollider.usedByEffector = false;
		}
	}
}
