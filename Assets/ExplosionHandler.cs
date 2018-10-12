using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour {

    public float timeTillDestroy = 0.25f;

    public Sprite[] possibleSprites;

	void Start ()
    {
        StartCoroutine(DelayDestroy());

        GetComponent<SpriteRenderer>().sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
	}

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }
}
