using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] GameObject tutorialScreen;
    // Start is called before the first frame update
    void Start()
    {
        tutorialScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tutorialScreen.SetActive(true);
        }
    }
}
