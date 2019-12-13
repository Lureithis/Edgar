using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfStones : Obstacle
{
    [SerializeField] GameObject insanityBar;
    [SerializeField] GameObject player;

    private InsanityBar insanityBarScript;
    private PolygonCollider2D transformCollider;
    private bool isInRocks;

    // Start is called before the first frame update
    void Start()
    {
        isInRocks = false;
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        transformCollider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        Use();
    }

    public override void Use()
    {
        if(insanityBarScript.isInHallucination == true)
        {
            transformCollider.isTrigger = true;
        }
        if (insanityBarScript.isInHallucination == false)
        {
            transformCollider.isTrigger = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if (player.transform.position.x <= transform.position.x + 10 && player.transform.position.x >= transform.position.x - 10 && isInRocks == true)
            {
                Debug.Log("HERE");
                    player.transform.position = new Vector3(collision.transform.position.x - 10, -10, player.transform.position.z);
                    isInRocks = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInRocks = true;
        }
    }
}
