using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAnimTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject manager;

    private Animator playerAnimator;
    private bool isHappening;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        isHappening = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isHappening == false)
            {
                isHappening = true;
                playerAnimator.SetTrigger("isFalling");
                manager.GetComponent<GameOver>().playAnim = true;
                manager.GetComponent<GameOver>().EndGame();
                
            }
            isHappening = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            //isHappening = false;
            manager.GetComponent<GameOver>().playAnim = false ;
        }
        
    }
}
