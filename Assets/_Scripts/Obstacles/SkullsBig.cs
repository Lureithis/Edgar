using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullsBig : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] float destroyTime = 10f;
    private InsanityBar insanitybarScript;
    private Vector3 originalSize;
    private bool isTransformed;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        insanitybarScript = gameManager.GetComponent<InsanityMode>().getInsanityBarScript();
        originalSize = transform.localScale;
        isTransformed = false;
        StartCoroutine(DestroySkull());
    }

    private void Update()
    {
            if(insanitybarScript.isInHallucination == true && isTransformed == false)
            {
                isTransformed = true;
                transform.localScale = new Vector2(transform.localScale.x - 1, transform.localScale.y - 1);
            }
            else if (insanitybarScript.isInHallucination == false)
            {
                
                transform.localScale = originalSize;
                isTransformed = false;
            }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            transform.GetComponent<Collider2D>().enabled = false;
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision.transform.GetComponent<Collider2D>());
        }
        else if (collision.collider.tag == "Player")
        {
            gameManager.GetComponent<GameOver>().EndGame();
            collision.transform.GetComponent<Collider2D>().enabled = false;
        }
    }

    IEnumerator DestroySkull()
    {
        yield return new WaitForSecondsRealtime(destroyTime);
        if (insanitybarScript.isInHallucination == false)
        {
            Destroy(gameObject);
        }
    }
}
