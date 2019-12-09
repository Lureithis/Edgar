using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBar : MonoBehaviour
{
    public bool isInHallucination;
    public Image insanityBar;
    public int levelOfInsanity;

    [SerializeField] GameOver gameManager;
    [SerializeField] float drainSpeed = 1;

    
    private GameOver gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        levelOfInsanity = 0;
        isInHallucination = false;
        gameOverScreen = gameManager.GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(insanityBar.fillAmount <= 0)
        {
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
        else
        {
            insanityBar.fillAmount += (drainSpeed * Time.deltaTime);
        }

        if (insanityBar.fillAmount <= 1 && insanityBar.fillAmount >= 0.66)
        {
            levelOfInsanity = 1;
        }
        else if (insanityBar.fillAmount < 0.66 && insanityBar.fillAmount >= 0.33)
        {
            levelOfInsanity = 2;
        }
        else if(insanityBar.fillAmount < 0.33 && insanityBar.fillAmount > 0)
        {
            levelOfInsanity = 3;
        }
    }
}
