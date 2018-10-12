using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public float health;
    public Slider healthBar;
    public Sprite[] explosionSprites;
    public GameObject explosionObj;

    public float ramDamageToItself = 25;
    public float ramDamageToPlayer = 0;

    float maxHealth;

    //Enemy health and shooting

	void Start () {
        maxHealth = health;
	}
	
	void Update () {

		if(health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = explosionSprites[Random.Range(0, explosionSprites.Length)];
            StartCoroutine(DelayDestroy());
        }
        else
        {
            healthBar.value = (health * 100 / maxHealth) / 100;
        }

	}

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(explosionObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Impacting with player");

            health -= ramDamageToItself;
        }
    }
}
