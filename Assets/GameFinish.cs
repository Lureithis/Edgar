using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameFinish : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameWonScreen;
    [SerializeField] GameObject PressE;
    [SerializeField] GameObject insanityBar;

    private InsanityBar bar;

    private void Start()
    {
        gameWonScreen.SetActive(false);
        PressE.SetActive(false);
        bar = insanityBar.GetComponent<InsanityBar>();
        
    }

    private void FinishGame()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        bar.enabled = false;
        gameWonScreen.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PressE.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                FinishGame();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PressE.SetActive(false);
        }
    }
}
