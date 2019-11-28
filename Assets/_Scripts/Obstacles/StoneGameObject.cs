﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGameObject : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    private InsanityBar insanitybarScript;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        insanitybarScript = gameManager.GetComponent<InsanityMode>().getInsanityBarScript();
        StartCoroutine(DestroyingStones());
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision.transform.GetComponent<Collider2D>());
        }
        else if (collision.collider.tag == "Player")
        {
            gameManager.GetComponent<GameOver>().EndGame();
        }
    }

    IEnumerator DestroyingStones()
    {
        yield return new WaitForSecondsRealtime(5f);
        if(insanitybarScript.isInHallucination == false)
        {
            Destroy(gameObject);
        }
    }
}
