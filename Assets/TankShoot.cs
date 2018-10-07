using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour {

    public GameObject[] projectilePrefabs;

    public Transform turretPos;

    public float bulletForce = 5f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject obj = Instantiate(projectilePrefabs[0], turretPos.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletForce, 0));
        }
    }
}
