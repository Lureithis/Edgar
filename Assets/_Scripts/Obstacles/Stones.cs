using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : Obstacle
{
    [SerializeField] GameObject insanityBar;
    [SerializeField] GameObject stone;
    [SerializeField] float spawnSpeed = 1f;
    [SerializeField] float destroySpeed = 5f;

    private InsanityBar insanityBarScript;
    private bool isSpawning;
    private bool isHallucinationOn;
    private List<GameObject> stones;
    private float randomWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        isHallucinationOn = false;
        isSpawning = false;
        stones = new List<GameObject>();
        insanityBarScript = insanityBar.GetComponent<InsanityBar>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (insanityBarScript.isInHallucination == true)
        {
            isHallucinationOn = true;
        }
        if (insanityBarScript.isInHallucination == false)
        {
            isHallucinationOn = false;
        }
        if (isHallucinationOn == true)
        {
            StartCoroutine(CheckForHallucination());
        }

        if (isSpawning == false)
        {
            isSpawning = true;
            Use();
        }
    }

    public override void Use()
    {
        StartCoroutine(SpawnStones());
    }

    IEnumerator SpawnStones()
    {
        if (isHallucinationOn == false)
        {
           
            float random = Random.Range(0, 1f);
            yield return new WaitForSecondsRealtime(random);
            
            Instantiate(stone, new Vector2(Random.Range((transform.position.x) / 2, (transform.position.x) * 2), transform.position.y), Quaternion.identity);
            yield return new WaitForSecondsRealtime(spawnSpeed);
            isSpawning = false;
        }
    }

    private IEnumerator CheckForHallucination()
    {
        GameObject[] stonesArray = GameObject.FindGameObjectsWithTag("Stone");
        Vector2 originalVelocity = GameObject.FindGameObjectWithTag("Stone").GetComponent<Rigidbody2D>().velocity;
        foreach (GameObject item in stonesArray)
        {
            item.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        yield return new WaitUntil(() => insanityBarScript.isInHallucination == false);
        foreach (GameObject item in stonesArray)
        {
            if(item)
            {
                item.GetComponent<Rigidbody2D>().velocity = originalVelocity;
            }
            
        }
        isSpawning = false;
    }
}
