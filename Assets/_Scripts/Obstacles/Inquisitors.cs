﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inquisitors : Obstacle
{
    [SerializeField] GameObject GameManager;

    private GameOver endgame;

    // Start is called before the first frame update
    void Start()
    {
        endgame = GameManager.GetComponent<GameOver>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            endgame.EndGame();
        }
    }

    public override void Use()
    {

    }
}
