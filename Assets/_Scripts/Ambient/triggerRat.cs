using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerRat : MonoBehaviour
{
    [SerializeField] GameObject Rat;
    [SerializeField] GameObject start;
    [SerializeField] GameObject end;
    
    private Vector3 startVector;
    private Vector3 endVector;
    private RatTriggerMovement RatScript;

    bool Triggered = false;
    bool firstTime = true;

    void Start()
    {
        endVector = end.transform.position;
        startVector = start.transform.position;
        RatScript = Rat.GetComponent<RatTriggerMovement>();
    }

    private void Update()
    {
        if(Triggered == true)
        {
            if(firstTime == true)
            {
                
                Rat.transform.position = startVector;
                firstTime = false;
               // StartCoroutine(DestroyRat());
            }
            
            RatScript.Run(endVector);
        }
    }

    IEnumerator DestroyRat()
    {
        yield return new WaitForSecondsRealtime(10f);
        //Destroy(gameObject);
        Destroy(Rat);
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Triggered == false)
        {
            if (collision.tag == "Player")
            {
                Triggered = true;
            }
        }
    }
}
