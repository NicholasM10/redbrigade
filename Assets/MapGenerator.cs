using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject player;
    public GameObject lastTileGenerated;

    public float maxIncline = 0.35f;

	void Start () {
        player = FindObjectOfType<TankController>().gameObject;
	}
	
	void Update () {
		
	}
}
