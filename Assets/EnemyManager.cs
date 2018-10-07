using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public float health;
    public Slider healthBar;
    public Sprite[] explosionSprites;

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

        Destroy(gameObject);

    }
}
