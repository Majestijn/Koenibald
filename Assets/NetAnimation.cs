using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAnimation : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            anim.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            anim.enabled = false;
    }
}
