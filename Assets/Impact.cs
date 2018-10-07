using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour {

    public Sprite[] explosionSprites;

    public float delay = 0.2f;

    public float damage = 25f;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void Explode()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<SpriteRenderer>().sprite = explosionSprites[Random.Range(0, explosionSprites.Length)];
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyManager>().health -= damage;
        }
        StartCoroutine(DelayExplode());
    }

    IEnumerator DelayExplode()
    {
        yield return new WaitForSeconds(delay);
        Explode();
    }
}
