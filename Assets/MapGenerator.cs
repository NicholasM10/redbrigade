using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject player;
    public GameObject lastTileGenerated;
    public float distanceFromPlayer;

    public GameObject tilePrefab;

    public float maxIncline = 0.35f;

	void Start () {
        player = FindObjectOfType<TankController>().gameObject;
	}
	
	void Update ()
    {
        distanceFromPlayer = Vector2.Distance(player.transform.position, lastTileGenerated.transform.position);

        if(distanceFromPlayer < 7.5)
        {
            GameObject obj = Instantiate(tilePrefab, lastTileGenerated.transform.position + new Vector3(1, GetIncline(), 0), Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            lastTileGenerated = obj;
        }
	}

    float GetIncline() //Get incline or downcline
    {
        return Random.Range(-maxIncline, maxIncline);
    }
}
