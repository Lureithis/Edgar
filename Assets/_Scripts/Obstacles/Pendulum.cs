using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Obstacle
{
    [SerializeField] GameObject manager;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            manager.GetComponent<GameOver>().EndGame();
        }
        
    }
    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
