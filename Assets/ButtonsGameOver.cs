using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsGameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] Player player;

    private PlayerStats stats;
    [SerializeField] GameObject manager;

    private void Start()
    {
        stats = manager.GetComponent<PlayerStats>();
    }


    public void ContinueGame()
    {
        GameOverScreen.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        manager.GetComponent<GameOver>().isPlayerDead = false;
        player.GetComponent<Animator>().enabled = true;
        player.transform.position = stats.locationSave;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
