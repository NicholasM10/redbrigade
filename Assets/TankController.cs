using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    public float tankSpeed = 5f;

    Rigidbody2D rb;

    public bool dir = true; //is facing to right

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.AddForce(new Vector2(tankSpeed, 0));
	}
}
