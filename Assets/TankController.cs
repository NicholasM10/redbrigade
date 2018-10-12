using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public float tankSpeed;

    public float climbRate = 5f;
    public float originalClimbRate;
    public float climbDistance = 0.5f;
    public float maxVelocity = 5f;

    public float health = 250;

    public LayerMask ignoreLayer;

    Rigidbody2D rb;

    public bool dir = true; //is facing to right

    public Transform[] raycastTransforms;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        originalClimbRate = climbRate;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.AddForce(new Vector2(tankSpeed, 0), ForceMode2D.Impulse);

        MaxVelocityLimit();
        CheckClimb();
	}

    void MaxVelocityLimit()
    {
        if(rb.velocity.x > maxVelocity)
        {
            rb.velocity = new Vector2(maxVelocity, rb.velocity.y);
        }
    }

    void ClimbForce()
    {
        Debug.Log(00);
        rb.AddForce(new Vector2(0, climbRate), ForceMode2D.Impulse);

        //To avoid getting stuck
        if(rb.velocity.x == 0)
        {
            climbRate *= 3;
            Debug.Log("Climbforce increased");
        }
        else
        {
            climbRate = originalClimbRate;
        }
    }

    void CheckClimb()
    {
        Debug.DrawRay(raycastTransforms[0].transform.position, Vector2.right);
        if (Physics2D.Raycast(raycastTransforms[0].transform.position, Vector2.right, climbDistance, ignoreLayer))
        {
            if (Physics2D.Raycast(raycastTransforms[1].transform.position, Vector2.right, climbDistance, ignoreLayer))
            {
                Debug.Log("Invalid collision");
            }
            else
            {
                ClimbForce();
                Debug.Log("Valid collision");
                //Todo: do animation here (rotation)
            }
        }
    }
}
