using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InsanityMode : MonoBehaviour
{
    [SerializeField] GameObject normalRoom;
    [SerializeField] GameObject insanityRoom01;
    [SerializeField] GameObject insanityRoom02;
    [SerializeField] GameObject insanityRoom03;
    [SerializeField] GameObject pendulum;
    [SerializeField] GameObject insanityBar;
    [SerializeField] GameObject reaper;
    [SerializeField] GameObject player;

    private InsanityBar insanityBarScript;
    private Renderer pendulumRend;
    private bool isActivated;
    private bool reaperMovementActivation;
    private Death_Movement movementDeath;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        normalRoom.SetActive(true);
        insanityRoom01.SetActive(false);
        insanityRoom02.SetActive(false);
        insanityRoom03.SetActive(false);
        pendulumRend = pendulum.GetComponent<SpriteRenderer>();
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        pendulumRend.enabled = false;
        reaperMovementActivation = false;
        movementDeath = reaper.GetComponent<Death_Movement>();
    }

    private void Update()
    {
        if(isActivated == true)
        {
            if (insanityBarScript.levelOfInsanity == 1)
            {
                insanityRoom01.SetActive(true);
                insanityRoom02.SetActive(false);
                insanityRoom03.SetActive(false);
            }
            else if (insanityBarScript.levelOfInsanity == 2)
            {
                insanityRoom02.SetActive(true);
                insanityRoom01.SetActive(false);
                insanityRoom03.SetActive(false);
            }
            else if (insanityBarScript.levelOfInsanity == 3)
            {
                insanityRoom03.SetActive(true);
                insanityRoom01.SetActive(false);
                insanityRoom02.SetActive(false);

                if(reaperMovementActivation == false)
                {
                    movementDeath.isHallucinationOn = true;
                    reaper.transform.position = new Vector3(player.transform.position.x - 10, player.transform.position.y, player.transform.position.z);
                    reaperMovementActivation = true;
                }
                
            }
        }
    }

    public InsanityBar getInsanityBarScript()
    {
        return insanityBarScript;
    }

    public void InsanityModeActivated()
    {
        isActivated = true;
        normalRoom.SetActive(false);
        pendulumRend.enabled = true; 
    }

    public void InsanityModeDeactivated()
    {
        movementDeath.isHallucinationOn = false;
        reaperMovementActivation = false;
        isActivated = false;
        normalRoom.SetActive(true);
        insanityRoom01.SetActive(false);
        insanityRoom02.SetActive(false);
        insanityRoom03.SetActive(false);
        pendulumRend.enabled = false;
    }
}
