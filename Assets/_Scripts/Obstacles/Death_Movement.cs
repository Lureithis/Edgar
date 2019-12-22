using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Movement : MonoBehaviour
{
    [SerializeField] GameObject manager;
    [SerializeField] GameObject player;
    [SerializeField] float speed = 0.5f;
    [SerializeField] GameObject end;

    private Vector3 originalPosition;
    private GameOver GameOverScript;

    public bool isHallucinationOn;
    // Start is called before the first frame update
    void Start()
    {
        isHallucinationOn = false;
        GameOverScript = manager.GetComponent<GameOver>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverScript.isPlayerDead == false && isHallucinationOn == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, speed);
        }
        if(isHallucinationOn == false && transform.position != originalPosition)
        {
            transform.position = originalPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            manager.GetComponent<GameOver>().EndGame();
        }
    }
}
