using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSkulls : Obstacle
{
    [SerializeField] GameObject skull;
    [SerializeField] float spawnSpeed = 1f;
    
    private bool isSpawning;
    private float randomWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSpawning == false)
        {
            StartCoroutine(SpawnSkulls());
        }
    }


    IEnumerator SpawnSkulls()
    {
        isSpawning = true;
        float random = Random.Range(0, 1f);
        yield return new WaitForSecondsRealtime(random);

        Instantiate(skull, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(spawnSpeed);
        isSpawning = false;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
