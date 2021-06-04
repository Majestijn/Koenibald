using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatController : MonoBehaviour
{
    public LayerMask whatIsKoelibald;
    private Collider2D myCollider;
    public PlayerController thePlayer;
    private Rigidbody2D myRigidBody;
    public GameObject playerPlacement;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        myCollider = GetComponent<Collider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // void Update()
    // {
    //     if (Physics2D.IsTouchingLayers(myCollider, whatIsKoelibald))
    //     {
    //         myRigidBody.velocity = new Vector2(4, 0);
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            myRigidBody.velocity = new Vector2(4, 0);
            thePlayer.myRigidBody.velocity = new Vector2(2, 0);
            //thePlayer.GetComponent<Rigidbody2D>().isKinematic = true;
            thePlayer.isOnBoat = true;
            //thePlayer.transform.SetParent(transform, true);
            //thePlayer.myRigidBody.velocity = Vector2.zero;
            thePlayer.GetComponent<Animator>().speed = 0;
        }
    }

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.transform.CompareTag("Player"))
		{
            thePlayer.GetComponent<Animator>().speed = 1;
   //         Vector3 savedPos = other.transform.position;
			//thePlayer.GetComponent<Rigidbody2D>().isKinematic = false;
			//thePlayer.isOnBoat = false;
			//thePlayer.transform.SetParent(null);
			//thePlayer.transform.position = savedPos;
		}
	}
}