using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedFishController : MonoBehaviour
{
	
	public Renderer myRend;
	public LayerMask whatIsProjectile;
	private Collider2D myCollider;
	public GameObject explosion;
	private bool happened;
	public GameObject position;
	public bool standard;
    public GameObject fish;
    void Start()
    {
       
		happened=false;
myCollider = GetComponent<Collider2D>();
 myRend = GetComponent<Renderer>();
 myRend.enabled=false;
       	}
		void Update(){
			if(Physics2D.IsTouchingLayers(myCollider, whatIsProjectile)){
			if(!happened){
			if(standard){
								Instantiate(explosion, new Vector3(transform.position.x,transform.position.y,transform.position.z), transform.rotation);

			}
			else{
				Instantiate(explosion, position.transform.position, transform.rotation);
			}
                Destroy(fish);
                myRend.enabled = true;
                happened = true;
			}
		}
		}

}