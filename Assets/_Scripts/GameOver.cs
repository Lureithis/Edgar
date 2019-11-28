using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameOver : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject gameOverScreen;

        public void EndGame()
        {
            gameOverScreen.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
