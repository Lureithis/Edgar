using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject InsanityBar;
    private bool isInHallucination;
    private InsanityMode insanitymode;
    private InsanityBar insanitybar;

    private void Start()
    {
        insanitymode = gameManager.GetComponent<InsanityMode>();
        insanitybar = InsanityBar.GetComponent<InsanityBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && isInHallucination == false)
        {
            isInHallucination = true;
            insanitymode.InsanityModeActivated();
            // InsanityBar.GetComponent<InsanityBar>().isInHallucinationChange();
            insanitybar.isInHallucinationChange();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && isInHallucination == true)
        {
            isInHallucination = false;
            insanitymode.InsanityModeDeactivated();
            insanitybar.isInHallucinationChange();
        }
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Obstacle")
         {
             Debug.Log("here");
             gameManager.GetComponent<GameOver>().GameOverScreen();
         }
     }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle" && collision.transform.GetComponent<Obstacle>().isDangerous == true)
        {
            gameManager.GetComponent<GameOver>().EndGame();
        }
        /*if (collision.collider.tag == "Obstacle" && collision.transform.GetComponent<Obstacle>().isDangerous == false)
        {
        }*/
    }


}
