using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Obstacle
{
    [SerializeField] GameObject manager;

    private bool dead;

    private void Start()
    {
        dead = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            if(dead == false)
            {
                manager.GetComponent<GameOver>().EndGame();
                dead = true;
            }
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dead = false;
    }
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
