using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float health;
    public Sprite[] explosionSprites;
    

    //Enemy health and shooting

	void Start () {
		
	}
	
	void Update () {
		if(health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = explosionSprites[Random.Range(0, explosionSprites.Length)];
            StartCoroutine(DelayDestroy());
        }
	}

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.25f);

        Destroy(gameObject);

    }
}
