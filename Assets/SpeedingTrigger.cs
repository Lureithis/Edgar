using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;

    private bool isSpeeding;
    // Start is called before the first frame update
    void Start()
    {
        isSpeeding = false;
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isSpeeding == false)
            {
                StartCoroutine(SpeedingLimit());
            }
        }
    }

    private IEnumerator SpeedingLimit()
    {
        isSpeeding = true;
        playerMovement.runSpeed = 50;
        yield return new WaitForSecondsRealtime(3f);
        playerMovement.runSpeed = 20;
        isSpeeding = false;
    }
}
