using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject InsanityBar;
    private bool isInHallucination;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && isInHallucination == false)
        {
            isInHallucination = true;
            gameManager.GetComponent<InsanityMode>().InsanityModeActivated();
            InsanityBar.GetComponent<InsanityBar>().isInHallucinationChange();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && isInHallucination == true)
        {
            isInHallucination = false;
            gameManager.GetComponent<InsanityMode>().InsanityModeDeactivated();
            InsanityBar.GetComponent<InsanityBar>().isInHallucinationChange();
        }
    }
}
