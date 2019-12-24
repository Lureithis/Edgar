using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : Obstacle
{
    [SerializeField] GameObject manager;

    [SerializeField] GameObject Insanity;
    private InsanityBar bar;

    private void Start()
    {
        bar = Insanity.GetComponent<InsanityBar>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if(bar.isInHallucination == false)
            {
                manager.GetComponent<GameOver>().EndGame();
            }
            
        }
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
