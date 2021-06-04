using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private Rigidbody2D myRigidBody,koenibaldBody;
    public GameObject Koenibald;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        koenibaldBody = Koenibald.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.velocity = new Vector2(koenibaldBody.velocity.x / 4, 0);

    }
}
