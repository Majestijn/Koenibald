using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpForce;
	public Rigidbody2D myRigidBody;
	public bool grounded;
	public LayerMask whatIsGround;
	public Renderer thisSheet;
	public bool canGameOver;
	public bool gameOver;
	public bool isWater;

	[SerializeField] private BoxCollider2D myCollider;

	private Animator myAnimator;
	public bool airJump;
	public AudioSource audioData;
	public AudioClip jumpSound, trashCan, shoot;
	public bool hasBucket;
	public LineRenderer lineRenderer;
	public GameObject Spear;
	private GameObject SpearBody;
	public GameObject shooteffect;
	public GameObject dead;
	public GameObject deadWaterEffect;
	public GameObject deadpos;
	public GameObject shootpos;
	public GameObject groundCheckPosition;
	public Sprite koeniebaldShovel;
	public BoxCollider2D shovelCollider;
	private SpriteRenderer spriteRenderer;
	private bool hasShovelHit = false;
	public bool hasShovelHitGrass = false;
	public float spearLifeSpan;
	public bool victory;
	public bool isShoveling;
	public float fallspeed;
	private float counter;
	public int maxCount;
	private bool deadeffect;
	private bool deadfromwater;
	private bool jump;
	public bool isOnBoat = false;
	private Coroutine disableShovelRoutine;

	void Start()
	{
		jump = false;
		deadfromwater = false;
		deadeffect = false;
		if (fallspeed == null) fallspeed = moveSpeed;
		isShoveling = false;
		SpearBody = null;
		myRigidBody = GetComponent<Rigidbody2D>();
		audioData = GetComponent<AudioSource>();
		myAnimator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		gameOver = false;
		airJump = false;
		victory = false;

		if (shovelCollider != null)
			shovelCollider.enabled = false;
	}

	void Update()
	{
		if (lineRenderer != null && lineRenderer.enabled) lineRenderer.enabled = false;

		grounded = IsGrounded();

		//DEPRECATED
		// if (Physics2D.IsTouchingLayers(myCollider, whatIsBoat) && !jump)
		// {
		//     myRigidBody.velocity = new Vector2(0, 0);
		// }

		if (SpearBody != null)
		{
			SpearBody.transform.position = new Vector3(shootpos.transform.position.x + 8,
				SpearBody.transform.position.y, SpearBody.transform.position.z);
		}

		//grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
		if (!isShoveling && !isOnBoat)
		{
			myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
		}
		else if (!isShoveling && isOnBoat)
		{
			myRigidBody.velocity = new Vector2(moveSpeed / 2, fallspeed);
			//if (counter < maxCount)
			//	counter++;
			//else
			//{
			//	counter = 0;
			//	isShoveling = false;
			//	myAnimator.SetBool("shovel", false);
			//}
		}
		else if (isShoveling && !isOnBoat)
		{
			myRigidBody.velocity = new Vector2(0, fallspeed);
			if (counter <= 2f)
				counter += Time.deltaTime;
			else
				DisableShoveling();
				

		}

		if (gameOver)
		{
			//if (!deadeffect)
			//{
			//    if (!deadfromwater) Instantiate(dead, deadpos.transform.position, transform.rotation);
			//    if (deadfromwater) Instantiate(deadWaterEffect, deadpos.transform.position, transform.rotation);
			//    deadeffect = true;
			//}

			thisSheet.enabled = false;
			myRigidBody.velocity = new Vector2(0, 0);
			return;
		}

		//DEPRECATED
		// if (Physics2D.IsTouchingLayers(myCollider, whatIsEnemy) && canGameOver)
		// {
		//     audioData.PlayOneShot(deadEnemy, 1);
		//     gameOver = true;
		// }
		//
		// if (Physics2D.IsTouchingLayers(myCollider, whatIsWater) && canGameOver)
		// {
		//     deadfromwater = true;
		//     audioData.PlayOneShot(deadWater, 1);
		//     gameOver = true;
		// }
		//}

		myAnimator.SetFloat("Speed", myRigidBody.velocity.x);

		if (!isWater)
		{
			myAnimator.SetBool("Grounded", grounded);
			myAnimator.SetBool("gameOver", gameOver);
		}


		if (Input.GetKeyDown("space"))
		{
			NormalJump();
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			spearThrow();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Shovel();
		}
	}

	public void DisableShoveling()
	{
		if (isShoveling)
		{
			shovelCollider.enabled = false;
			isShoveling = false;
			hasShovelHitGrass = false;
			myAnimator.enabled = true;
			myAnimator.SetBool("shovel", false);
			disableShovelRoutine = null;
			counter = 0f;
		}
	}

	//Een public functie die enemies kunnen aanroepen als de speler tegen ze aanloopt. Neemt een audioclip als parameter voor de death sound.
	public void Die(AudioClip deathSound, GameObject deathParticle)
	{
		if (deathSound != null)
			audioData.PlayOneShot(deathSound, 1);

		if (deathParticle != null)
			Instantiate(deathParticle, groundCheckPosition.transform.position, Quaternion.identity);

		print("Koeniebald died!");
		gameOver = true;
	}

	public bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.BoxCast(groundCheckPosition.transform.position, new Vector2(myCollider.bounds.size.x, myCollider.bounds.size.y), 0f, Vector2.down, .2f, whatIsGround);
		if (hit.collider != null)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public IEnumerator DisableShovelRoutine()
	{
		yield return new WaitForSeconds(.2f);
		DisableShoveling();
	}

	public void DisablePic()
	{
		thisSheet.enabled = false;
		victory = true;
	}

	public void spearThrow()
	{
		if (SpearBody == null && hasBucket)
		{
			Instantiate(shooteffect, shootpos.transform.position, transform.rotation);
			SpearBody = Instantiate(Spear,
				new Vector3(shootpos.transform.position.x + 8, shootpos.transform.position.y,
					shootpos.transform.position.z), shootpos.transform.rotation);
			Destroy(SpearBody, spearLifeSpan);
			if (lineRenderer != null)
				lineRenderer.enabled = true;
			audioData.PlayOneShot(shoot, 1);
		}
	}

	public void Shovel()
	{
		if (hasBucket && !IsGrounded() && !isShoveling)
		{
			//grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
			isShoveling = true;
			shovelCollider.enabled = true;
			myAnimator.SetBool("shovel", true);
		}
	}

	public void NormalJump()
	{
		//grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
		//if (Physics2D.IsTouchingLayers(myCollider, whatIsBoat)) jump = true;

		if (!isShoveling)
		{
			if (grounded || isWater)
			{
				if (isOnBoat)
				{
					Vector3 savedPos = transform.position;
					myRigidBody.isKinematic = false;
					transform.SetParent(null);
					isOnBoat = false;
					transform.position = savedPos;
				}

				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
				airJump = true;
				audioData.PlayOneShot(jumpSound, 1);
			}

			if (airJump && !grounded)
			{
				myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
				airJump = false;
				audioData.PlayOneShot(jumpSound, 1);
			}
		}
	}

	public bool PickUp(bool isBucket)
	{
		if (isBucket)
		{
			if (!hasBucket)
			{
				audioData.PlayOneShot(trashCan);
			}

			hasBucket = true;
			myAnimator.SetBool("hasBucket", true);

			return false;
		}

		else if (hasBucket && !isBucket)
		{
			if (!audioData.isPlaying)
			{
				audioData.PlayOneShot(trashCan);
			}

			return false;
		}

		return false;
	}
}