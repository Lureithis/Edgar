using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSkulls : Obstacle
{
    [SerializeField] GameObject skullBIG;
    [SerializeField] GameObject skullSMALL;
    [SerializeField] float spawnSpeed = 1f;
    
    private bool isSpawning;
    private float randomWaitTime;
    private List<GameObject> skulls;
    private int randomSpawn;

    // Start is called before the first frame update
    void Start()
    {
        skulls = new List<GameObject>();
        skulls.Add(skullBIG);
        skulls.Add(skullSMALL);
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
        randomSpawn = Random.Range(0, 2);
        Instantiate(skulls[randomSpawn], transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(spawnSpeed);
        isSpawning = false;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
