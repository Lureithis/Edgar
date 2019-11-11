using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityBar : MonoBehaviour
{
    public bool isInHallucination;
    [SerializeField] Image insanityBar;
    [SerializeField] float drainSpeed = 1;
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        isInHallucination = false;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(insanityBar.fillAmount <= 0)
        {
            gameOverScreen.SetActive(true);
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
