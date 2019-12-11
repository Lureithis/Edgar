using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadTrapsPreview()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGamePreview()
    {
        SceneManager.LoadScene(1);
    }

    /* public GameObject LockedText;
     public bool isLocked;
     public int sceneToLoad;

     private bool isInTrigger;

     private void OnTriggerEnter2D(Collider2D collision)
     {
         isInTrigger = true;   
     }

     IEnumerator showLockedText()
     {
         LockedText.SetActive(true);
         yield return new WaitForSecondsRealtime(3f);
         LockedText.SetActive(false);
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         isInTrigger = false;
     }

     private void Update()
     {
         if (Input.GetKeyDown(KeyCode.W) && isInTrigger)
         {
             if (isLocked)
             {
                 StartCoroutine(showLockedText());
             }

             else
             {
                 SceneManager.LoadScene(sceneToLoad);
             }
         }
     }*/
}
