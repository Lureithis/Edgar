using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectItem : MonoBehaviour
{
    public GameObject screenToShowOnTrigger;
    public GameObject infoAboutObject;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            this.screenToShowOnTrigger.SetActive(true);
           
        }
            
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.screenToShowOnTrigger.SetActive(false);
            this.infoAboutObject.SetActive(false);
        }
            
    }

    private void Update()
    {
        if(screenToShowOnTrigger.active == true && Input.GetKeyDown(KeyCode.E))
        {
            this.infoAboutObject.SetActive(true);
        }
    }
}
