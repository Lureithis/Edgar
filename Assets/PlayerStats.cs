using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Vector3 locationSave;

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        locationSave = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
