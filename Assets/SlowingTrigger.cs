using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingTrigger : MonoBehaviour
{
    [SerializeField] GameObject player;

    private PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerMovement.runSpeed = 20;
        }
    }
}
