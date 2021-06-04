using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugController : MonoBehaviour
{
	public float moveSpeed;
	private Rigidbody2D myRigidBody;
	//public layermask whatisenemy en dan onderin zegge gameover
	

    // Start is called before the first frame update
    void Start()
    {
  myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
		
		
		
    }
}
