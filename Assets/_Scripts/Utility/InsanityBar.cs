using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBar : MonoBehaviour
{
    public bool isInHallucination;
    public Image insanityBar;
    [SerializeField] GameOver gameManager;
    [SerializeField] float drainSpeed = 1;
    private GameOver gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        isInHallucination = false;
        gameOverScreen = gameManager.GetComponent<GameOver>();
       // gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(insanityBar.fillAmount <= 0)
        {
            // gameOverScreen.SetActive(true);
            gameOverScreen.EndGame();
        }

        UpdateInsanityBar();
    }

    public void isInHallucinationChange()
    {
        isInHallucination = !isInHallucination;
    }

    private void UpdateInsanityBar()
    {
        if (isInHallucination == true)
        {
            insanityBar.fillAmount -= (drainSpeed * Time.deltaTime);
        }
        if (isInHallucination == false)
        {
            insanityBar.fillAmount += (drainSpeed * Time.deltaTime);
        }
    }
}
