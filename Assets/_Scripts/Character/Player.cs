using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject InsanityBar;
    
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
        ChangeHallucination();
    }

    private void ChangeHallucination()
    {
        if (Input.GetKeyDown(KeyCode.Q) && insanitybar.isInHallucination == false)
        {
            insanitymode.InsanityModeActivated();
            insanitybar.isInHallucinationChange();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && insanitybar.isInHallucination == true)
        {
            insanitymode.InsanityModeDeactivated();
            insanitybar.isInHallucinationChange();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Obstacle" && collision.transform.GetComponent<Obstacle>().isDangerous == true)
        {
            gameManager.GetComponent<GameOver>().EndGame();
        }
    }


}
