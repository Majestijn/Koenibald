using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject deathParticle;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerController playerController = other.transform.GetComponent<PlayerController>();
            
            if (!playerController.gameOver)
                playerController.Die(deathSound, deathParticle);
        }
    }
}
