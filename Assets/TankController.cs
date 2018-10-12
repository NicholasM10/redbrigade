using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public float tankSpeed = 5f;

    public float climbRate = 5f;
    public float climbDistance = 0.5f;

    public float health = 250;

    public LayerMask ignoreLayer;

    Rigidbody2D rb;

    public bool dir = true; //is facing to right

    public Transform[] raycastTransforms;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(new Vector2(tankSpeed, 0), ForceMode2D.Force);

        CheckClimb();
	}

    void ClimbForce()
    {
        rb.AddForce(new Vector2(0, climbRate), ForceMode2D.Force);
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
                //Todo: do animation here (rotation)
            }
        }
    }
}
